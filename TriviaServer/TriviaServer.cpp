#include <WinSock2.h>
#include <Windows.h>
#include "TriviaServer.h"
#include "Game.h"
#include "User.h"
#include "RecievedMessage.h"
#include "Room.h"
#include "Question.h"
#include "Validator.h"
#include <exception>
#include <thread>
#include <mutex>
#include <vector>
#include "Protocol.h"

using std::exception;
using std::lock_guard;
using std::thread;

TriviaServer::TriviaServer()
{
	DataBase* temp = new DataBase();
	_db = *temp;

	try
	{
		_socket = ::socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

		if (_socket == INVALID_SOCKET)
			throw std::exception(__FUNCTION__ " - socket");
	}
	catch (exception& e)
	{
		cout << e.what() << endl;
	}
}

TriviaServer::~TriviaServer()
{
	_roomsList.clear();
	_connectedUsers.clear();
	
	try
	{
		// the only use of the destructor should be for freeing 
		// resources that was allocated in the constructor
		::closesocket(_socket);
	}
	catch (...) {}
}

void TriviaServer::serve()
{
	this->bindAndListen();
	thread tr(&TriviaServer::handleRecievedMessage, this);
	tr.detach();

	while (true)
	{
		TRACE("accepting client...");
		this->accept();
	}
}

void TriviaServer::bindAndListen()
{
	struct sockaddr_in sa = { 0 };
	sa.sin_port = htons(PORT);
	sa.sin_family = AF_INET;
	sa.sin_addr.s_addr = IFACE;

	if (::bind(_socket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - bind");

	cout << "binded" << endl;

	if (::listen(_socket, SOMAXCONN) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - listen");
	cout <<"Listening on port " << PORT << endl;
}

void TriviaServer::accept()
{
	while (true)
	{
		SOCKET client_socket = ::accept(_socket, NULL, NULL);

		if (client_socket == INVALID_SOCKET)
			throw std::exception(__FUNCTION__);

		cout << "Client accepted !.  SOCKET = " << client_socket << endl;
		// create new thread for client	and detach from it
		thread tr(&TriviaServer::clientHandler, this, client_socket);
		tr.detach();
	}
}

void TriviaServer::clientHandler(SOCKET sock)
{
	int msgCode = Helper::getMessageTypeCode(sock);
	RecievedMessage* theReturnedMessage;

	try
	{
		while (msgCode != MT_CLIENT_EXIT)
		{
			theReturnedMessage = this->buildRecieveMessage(sock, msgCode);
			this->addRecieveMessage(theReturnedMessage);
			this->handleRecievedMessage();
			msgCode = Helper::getMessageTypeCode(sock);
		}
		if (msgCode == MT_CLIENT_EXIT)
		{
			closesocket(sock);
			cout << "handleRecievedMessages: msgCode = 299, client_socket : " << sock << endl;
			cout << "Client Out !!!" << endl;
		}
	}
	catch (exception &e)
	{
		cout << e.what() << endl;
		RecievedMessage* errorRcvMsg = new RecievedMessage(sock, 299);
		this->addRecieveMessage(errorRcvMsg);
		closesocket(sock);
	}

	this->safeDeleteUser(new RecievedMessage(sock, msgCode));
	cout << "Comunication Down!!" << endl;
}

void TriviaServer::safeDeleteUser(RecievedMessage * msg)
{
	try
	{
		SOCKET sock= msg->getSock();
		this->handleSignout(msg);
		closesocket(sock);
	}
	catch (exception& e)
	{
		cout << e.what() << endl;
	}
}

User * TriviaServer::handleSignin(RecievedMessage * msg)
{
	try
	{
		vector<string> details = msg->getValues();
		string username = details[0];
		string password = details[1];

		cout << "--------------------" << endl;
		cout << "handleRecievedMessages: msgCode = 200, client_socket : " << msg->getSock() << endl;

		if (_db.isUserAndPassMatch(username, password))
		{
			if (this->getUserByName(username))
			{
				_Protocol.response102("2", msg->getSock()); // user is already connected
				cout << "Message sent to user : " << username << ", msg : 1022" << endl;
				cout << "SEND: username = " << username << " is already connected" << ", socket = " << msg->getSock() << endl;
				cout << "--------------------" << endl;
			}
			else
			{
				User* newUser = new User(username, msg->getSock());
				_mtxUsers.lock();
				_connectedUsers.insert(pair<SOCKET, User*>(msg->getSock(), newUser));
				_mtxUsers.unlock();
				_Protocol.response102("0", msg->getSock()); // success

				cout << "Message sent to user : " << newUser->getUsername() << ", msg : 1020" << endl;
				cout << "SEND: User signed in successfuly: username = " << newUser->getUsername() << ", socket = " << msg->getSock() << endl;
				cout << "--------------------" << endl;
			
				return newUser;
			}
		}
		else
		{
			_Protocol.response102("1", msg->getSock()); // wrong details
			cout << "Message sent to user : " << username << ", msg : 1021" << endl;
			cout << "SEND: wrong detalis for username = " << username << ", socket = " << msg->getSock() << endl;
			cout << "--------------------" << endl;
		}

	}
	catch (exception& e)
	{
		cout << e.what() << endl;
	}

	return nullptr;
}

bool TriviaServer::handleSignup(RecievedMessage * msg)
{
	/*
	SEND: User signed up successfuly: username = usersad, socket = 272
	*/
	string username = msg->getValues()[0];
	string password = msg->getValues()[1];
	string email = msg->getValues()[2];

	cout << "--------------------" << endl;
	cout << "handleRecievedMessages: msgCode = 203, client_socket : " << msg->getSock() << endl;

	if (Validator::isPasswrodValid(password))
	{
		if (Validator::isUserNameValid(username))
		{
			if (_db.isUserExist(username))
			{
				_Protocol.response104("2", msg->getSock());
				cout << "User signup failed. User already exist : " << username << ", socket = " << msg->getSock() << endl;
			}
			else
			{
				try
				{
					_db.addNewUser(username, password, email);
					cout << "SEND: User signed up successfuly : " << username << ", socket = " << msg->getSock() << endl;
					_Protocol.response104("0", msg->getSock());
					return true;
				}
				catch (exception& e)
				{
					cout << e.what() << endl;
					_Protocol.response104("4", msg->getSock());
				}
			}
		}
		else
		{
			_Protocol.response104("3", msg->getSock()); // username is illegal
			cout << "SEND: User signup failed. Invalid username : username = " << username << ", socket = " << msg->getSock() << endl;
		}
	}
	else
	{
		_Protocol.response104("1", msg->getSock()); // pass illegal
		cout << "SEND: User signup failed. Invalid password : username = " << username << ", socket = " << msg->getSock() << endl;
	}
	cout << "--------------------" << endl;

	return false;
}

void TriviaServer::handleSignout(RecievedMessage * msg)
{
	try
	{
		cout << "--------------------" << endl;
		User* user = this->getUserBySocket(msg->getSock());

		if (user != nullptr)
		{
			usersItr = _connectedUsers.find(msg->getSock());
			_connectedUsers.erase(usersItr);
			//this->handleCloseRoom(msg);
			//this->handleLeaveRoom(msg);
			//this->handleLeaveGame(msg);
			cout << "--------------------" << endl;
			cout << "handleRecievedMessages: msgCode = 121" << ", client_socket : " << msg->getSock() << endl;
			cout << "Erase user from connected users list : username =" << user->getUsername() << ", socket = " << msg->getSock() << endl;
			cout << "handleLeaveGame : Game was ended and released from memory" << endl;
			cout << "User had signedout : username = " << user->getUsername() << ", socket = " << user->getSocket() << endl;
			cout << "--------------------" << endl;
			//closesocket(msg->getSock());
		}
	}
	catch (exception& e)
	{
		cout << e.what() << endl;
	}
}

void TriviaServer::handleForgotPassworrd(RecievedMessage * msg)
{
	string username = msg->getValues()[0];

	cout << "--------------------" << endl;
	cout << "handleRecievedMessages: msgCode = 227, client_socket : " << msg->getSock() << endl;

	try
	{
		string password = _db.restPassword(username);
		if (password != "")
		{
			_Protocol.response127(msg->getSock(), password, true);
			cout << "SEND: password is found. username : " << username << ", password : << " << password << ", socket = " << msg->getSock() << endl;
		}
		else
		{
			_Protocol.response127(msg->getSock(), password, false);
			cout << "SEND: password is not found. username : " << username << ", password : " << password << ", socket = " << msg->getSock() << endl;
		}
	}
	catch (exception& e)
	{
		cout << e.what() << endl;
	}
	cout << "--------------------" << endl;
}

void TriviaServer::handleLeaveGame(RecievedMessage * msg)
{
	if (this->getUserBySocket(msg->getSock())->leaveGame())
	{
		msg->getUser()->setGame(nullptr);
	}
}

void TriviaServer::handleStartGame(RecievedMessage * msg)
{
	User* user = this->getUserBySocket(msg->getSock());
	int roomID = user->getRoom()->getID();

	try
	{
		Game* newGame = new Game(user->getRoom()->getUsers(), user->getRoom()->getQuestionNumber(), _db);
		newGame->sendFirstQuestion();
		//_roomsList.erase(roomID);
	}
	catch (exception& e)
	{
		cout << e.what() << endl;
		_Protocol.response118(nullptr, user);
	}
}

void TriviaServer::handlePlayerAnswer(RecievedMessage * msg)
{
	User* user = this->getUserBySocket(msg->getSock());
	int answerNumber = std::stoi(msg->getValues()[0]);
	int time = std::stoi(msg->getValues()[1]);

	cout << "--------------------" << endl;
	cout << "handleRecievedMessages: msgCode = 219, client_socket : " << msg->getSock() << endl;
	cout << "AnswerNo = " << answerNumber << ", time = " << time << ", CorrectAnswer = " << user->getGame()->getCurrentQuestion()->getCorrectAnswerIndex() + 1 << endl;
	cout << "Sending answer indiction to user." << endl;

	if (user->getGame() != nullptr)
	{
		if (!(user->getGame()->handleAnswerFromUser(user, answerNumber, time)))
		{
			user->setGame(nullptr);
			cout << "Message sent to user : " << user->getUsername() << ", msg : 1201" << endl;
		}
	}
	cout << "--------------------" << endl;
}

bool TriviaServer::handleCreateRoom(RecievedMessage * msg)
{
	User* user = this->getUserBySocket(msg->getSock());
	string roomName = msg->getValues()[0];
	int playersNumber = std::stoi(msg->getValues()[1]);
	int questionsNumber = std::stoi(msg->getValues()[2]);
	int questionTime = std::stoi(msg->getValues()[3]);
	
	cout << "--------------------" << endl;
	cout << "handleRecievedMessages: msgCode = 213, client_socket : " << msg->getSock() << endl;


	if (user != nullptr)
	{
		_roomIdSequence++;

		if (user->createRoom(_roomIdSequence, roomName, playersNumber, questionsNumber, questionTime))
		{
			_roomsList.insert(pair<int, Room*>(_roomIdSequence, user->getRoom()));
			_Protocol.response114(0, msg->getSock());
			cout << "Message sent to user : " << user->getUsername() << ", msg : 1140" << endl;
			cout << "Room was created, Admin: " << user->getUsername() << ", room name : " << user->getRoom()->getName() << ", room id : " << user->getRoom()->getID() << ", players number : " << user->getRoom()->getMaxUsersNumber() << ", question number : " << user->getRoom()->getQuestionNumber() << ", answer time : " << user->getRoom()->getQuestionTime() << endl;
			cout << "--------------------" << endl;

			return true;
		}
	}
	else
	{
		_Protocol.response114(1, msg->getSock());
		cout << "Message sent to user : " << user->getUsername() << ", msg : 1141" << endl;
	}
	cout << "--------------------" << endl;

	return false;
}

bool TriviaServer::handleCloseRoom(RecievedMessage * msg)
{
	User* user = this->getUserBySocket(msg->getSock());
	Room* room = user->getRoom();
	
	cout << "--------------------" << endl;
	cout << "handleRecievedMessages: msgCode = 215, " << "client_socket : " << msg->getSock() << endl;
	cout << "SEND : Room sending message to 1 users([ " << user->getUsername() << "]) : message = 116" << endl;
	cout << "Message sent to user : " << user->getUsername() << ", msg : 116" << endl;

	if (room != nullptr)
	{
		if (user->closeRoom() != -1)
		{
			cout << "Room was closed : roomId = " << room->getID() << ", roomName = " << room->getName() << ", closingUser = " << user->getUsername() << endl;
			cout << "--------------------" << endl;
			user->closeRoom();
			_roomsList.erase(room->getID());
			_Protocol.response116(msg->getSock());
			return true;
		}
	}
	cout << "--------------------" << endl;

	return false;
}

bool TriviaServer::handleJoinRoom(RecievedMessage * msg)
{
	User* user = this->getUserBySocket(msg->getSock());
	int roomID = std::stoi(msg->getValues()[0]);
	Room* room = nullptr;

	if (user != nullptr)
	{
		try
		{
			room = this->getRoomByID(roomID);
			if (room != nullptr)
			{
				if (room->getUsers().size() == room->getMaxUsersNumber())
				{
					_Protocol.response110(room->getQuestionNumber(), room->getQuestionTime(), 1, room, msg->getSock());
					return false;
				}
				else
				{
					user->joinRoom(room);
					_Protocol.response110(room->getQuestionNumber(), room->getQuestionTime(), 0, room, msg->getSock());
					return true;

				}
			}
			else
			{
				_Protocol.response110(room->getQuestionNumber(), room->getQuestionTime(), 2, room, msg->getSock());
				return false;
			}

		}
		catch (exception& e)
		{
			cout << e.what() << endl;
		}
	}

	return false;
}

bool TriviaServer::handleLeaveRoom(RecievedMessage * msg)
{
	User* user = this->getUserBySocket(msg->getSock());
	
	if (user != nullptr)
	{
		Room* room = user->getRoom();
		
		if (room != nullptr)
		{
			user->leaveRoom();
			_Protocol.response112(msg->getSock(), true);
			return true;
		}
		else
		{
			_Protocol.response112(msg->getSock(), false);
			return false;
		}
	}
	_Protocol.response112(msg->getSock(), false);

	return false;
}

void TriviaServer::handleGetUserslnRoom(RecievedMessage * msg)
{
	User* user = this->getUserBySocket(msg->getSock());
	int roomID = std::stoi(msg->getValues()[0]);
	Room* room = this->getRoomByID(roomID);

	if (room != nullptr)
	{
		Helper::sendData(msg->getSock(), room->getUserListMessage());
	}
	else
	{
		Helper::sendData(msg->getSock(), room->getUserListMessage());
	}
}

void TriviaServer::handleGetRooms(RecievedMessage * msg)
{
	vector<Room*> rooms;
	for (roomsItr = _roomsList.begin(); roomsItr != _roomsList.end(); ++roomsItr)
	{
		rooms.push_back(roomsItr->second);
	}
	_Protocol.response106(rooms, msg->getSock());
}

void TriviaServer::handleGetBestScore(RecievedMessage * msg)
{
	User* user = getUserBySocket(msg->getSock());
	vector<string> playersBestScore = _db.getBestScores();
	_Protocol.response124(msg->getSock(), playersBestScore, user->getUsername());
}

void TriviaServer::handleGetPersonalStatus(RecievedMessage * msg)
{
	User* user = getUserBySocket(msg->getSock());
	vector<string> personalStatus = _db.getPersonalStatus(user->getUsername());
	_Protocol.response126(msg->getSock(), personalStatus, user->getUsername());
}

void TriviaServer::handleRecievedMessage()
{
	std::unique_lock<mutex> locker(_mtxRecievedMessages);

	if (_queRcvMessages.empty())
	{
		_msgCondition.wait(locker);
	}

	RecievedMessage* rcvMsg = _queRcvMessages.front();

	try
	{
		switch (rcvMsg->getMessageCode())
		{
		case MT_CLIENT_SIGN_IN:
			this->handleSignin(rcvMsg);
			break;

		case MT_CLIENT_SIGN_OUT:
			this->handleSignout(rcvMsg);
			break;

		case MT_CLIENT_SIGN_UP:
			this->handleSignup(rcvMsg);
			break;

		case MT_CLIENT_GET_ROOMS:
			this->handleGetRooms(rcvMsg);
			break;

		case MT_CLIENT_GET_USERS_IN_ROOM:
			this->handleGetUserslnRoom(rcvMsg);
			break;

		case MT_CLIENT_JOIN_ROOM:
			this->handleJoinRoom(rcvMsg);
			break;

		case MT_CLIENT_LEAVE_ROOM:
			this->handleLeaveRoom(rcvMsg);
			break;

		case MT_CLIENT_CREATE_ROOM:
			this->handleCreateRoom(rcvMsg);
			break;

		case MT_CLIENT_CLOSE_ROOM:
			this->handleCloseRoom(rcvMsg);
			break;

		case MT_CLIENT_START_GAME:
			this->handleStartGame(rcvMsg);
			break;

		case MT_CLIENT_PLAYERS_ANSWER:
			this->handlePlayerAnswer(rcvMsg);
			break;

		case MT_CLIENT_LEAVE_GAME:
			this->handleLeaveGame(rcvMsg);
			break;

		case MT_CLIENT_GET_BEST_SCORE:
			this->handleGetBestScore(rcvMsg);
			break;

		case MT_CLIENT_GET_PERSONAL_STATUS:
			this->handleGetPersonalStatus(rcvMsg);
			break;

		case MT_CLIENT_FORGOT_PASSWORD:
			this->handleForgotPassworrd(rcvMsg);
			break;

		default:
			this->safeDeleteUser(rcvMsg);

		}
		delete rcvMsg;
		_queRcvMessages.pop();
	}

	catch (exception& e)
	{
		cout << e.what() << endl;
		this->safeDeleteUser(rcvMsg);
	}
}

void TriviaServer::addRecieveMessage(RecievedMessage * msg)
{
	lock_guard<mutex> lck(_mtxRecievedMessages);
	_queRcvMessages.push(msg);
	//lck.~lock_guard();
	//_msgCondition.notify_all();
}

RecievedMessage * TriviaServer::buildRecieveMessage(SOCKET sock, int msgCode)
{
	vector<string> parameters;
	int byte = 0; 

	if (msgCode == MT_CLIENT_SIGN_IN)
	{
		for (int i = 0; i < 2; i++)
		{
			byte = Helper::getIntPartFromSocket(sock, 2);
			parameters.push_back(string(Helper::getStringPartFromSocket(sock, byte)));
		}

		RecievedMessage * msg = new RecievedMessage(sock, msgCode, parameters);
		parameters.clear();
		return msg;
	}
	else if (msgCode == MT_CLIENT_SIGN_OUT)
	{
		RecievedMessage * msg = new RecievedMessage(sock, msgCode);
		return msg;
	}
	else if (msgCode == MT_CLIENT_SIGN_UP)
	{
		for (int i = 0; i < 3; i++)
		{
			byte = Helper::getIntPartFromSocket(sock, 2);
			parameters.push_back(string(Helper::getStringPartFromSocket(sock, byte)));
		}

		RecievedMessage * msg = new RecievedMessage(sock, msgCode, parameters);
		parameters.clear();
		
		return msg;
	}

	else if (msgCode == MT_CLIENT_GET_ROOMS)
	{
		RecievedMessage * msg = new RecievedMessage(sock, msgCode);
		return msg;
	}
	else if (msgCode == MT_CLIENT_GET_USERS_IN_ROOM)
	{
		
		parameters.push_back(string(Helper::getStringPartFromSocket(sock, 4)));
	
		RecievedMessage * msg = new RecievedMessage(sock, msgCode, parameters);
		parameters.clear();
		return msg;
	}
	else if (msgCode == MT_CLIENT_JOIN_ROOM)
	{
		parameters.push_back(string(Helper::getStringPartFromSocket(sock, 4)));

		RecievedMessage * msg = new RecievedMessage(sock, msgCode, parameters);
		parameters.clear();
		return msg;
	}
	else if (msgCode == MT_CLIENT_LEAVE_ROOM)
	{
		RecievedMessage * msg = new RecievedMessage(sock, msgCode);
		return msg;
	}
	else if (msgCode == MT_CLIENT_CREATE_ROOM)
	{
		byte = Helper::getIntPartFromSocket(sock, 2);
		parameters.push_back(string(Helper::getStringPartFromSocket(sock, byte)));
		parameters.push_back(string(Helper::getStringPartFromSocket(sock, 1)));
		parameters.push_back(string(Helper::getStringPartFromSocket(sock, 2)));
		parameters.push_back(string(Helper::getStringPartFromSocket(sock, 2)));

		RecievedMessage * msg = new RecievedMessage(sock, msgCode, parameters);
		parameters.clear();
		return msg;
	}
	else if (msgCode == MT_CLIENT_CLOSE_ROOM)
	{
		RecievedMessage * msg = new RecievedMessage(sock, msgCode);
		return msg;
	}
	else if (msgCode == MT_CLIENT_START_GAME)
	{
		RecievedMessage * msg = new RecievedMessage(sock, msgCode);
		return msg;
	}
	else if (msgCode == MT_CLIENT_PLAYERS_ANSWER)
	{
		parameters.push_back(Helper::getStringPartFromSocket(sock, 1));
		parameters.push_back(Helper::getStringPartFromSocket(sock, 2));

		RecievedMessage * msg = new RecievedMessage(sock, msgCode, parameters);
		parameters.clear();
		return msg;
	}
	else if(msgCode == MT_CLIENT_LEAVE_GAME)
	{
		RecievedMessage * msg = new RecievedMessage(sock, msgCode);
		return msg;
	}
	else if(msgCode == MT_CLIENT_GET_BEST_SCORE)
	{
		RecievedMessage * msg = new RecievedMessage(sock, msgCode);
		return msg;
	}
	else if(msgCode == MT_CLIENT_GET_PERSONAL_STATUS)
	{
		RecievedMessage * msg = new RecievedMessage(sock, msgCode);
		return msg;
	}
	else if (msgCode == MT_CLIENT_FORGOT_PASSWORD)
	{
		byte = Helper::getIntPartFromSocket(sock, 4);
		parameters.push_back(string(Helper::getStringPartFromSocket(sock, byte)));

		RecievedMessage * msg = new RecievedMessage(sock, msgCode, parameters);
		parameters.clear();
		return msg;
	}
	else
	{

	}
	
	return nullptr;
}

User * TriviaServer::getUserByName(string username)
{
	for (usersItr = _connectedUsers.begin(); usersItr != _connectedUsers.end(); ++usersItr)
	{
		if (usersItr->second->getUsername() == username)
		{
			return (usersItr->second);
		}
	}

	return nullptr;
}

User * TriviaServer::getUserBySocket(SOCKET sock)
{
	for (usersItr = _connectedUsers.begin(); usersItr != _connectedUsers.end(); ++usersItr)
	{
		if (usersItr->first == sock)
		{
			return (usersItr->second);
		}
	}

	return nullptr;
}

Room * TriviaServer::getRoomByID(int id)
{
	for (roomsItr = _roomsList.begin(); roomsItr != _roomsList.end(); ++roomsItr)
	{
		if (roomsItr->first == id)
		{
			return _roomsList[id];
		}
	}
	return nullptr;
}
