#include "DataBase.h"
#include <exception>
#include <sstream>
#include <time.h>
#include <algorithm> 
#include <chrono>
#include <ctime>
#include <string>
#include <map>


#define RETRIVING_ERROR "ERROR, while retriving information."
#define INSERTING_ERROR "ERROR, while inserting information."
#define UPDATING_ERROR "ERROR, IN UPDATING."
#define ERROR_RETURN -1

using std::exception;
using std::stringstream;
using std::chrono::system_clock;
using std::ctime;
using std::map;

unordered_map<string, vector<string>> results;

#pragma warning(disable : 4996)

DataBase::DataBase()
{
	int rc;
	rc = sqlite3_open("trivia.db", &_db);
	
	try
	{
		if (rc != SQLITE_OK)
		{
			throw (exception("Can't open database"));
			sqlite3_close(_db);
		}

		else
		{
			stringstream gamesTable, playersAnswersTable, questionsTable, usersTable, fk;
			/*
			gamesTable << "create table t_games(id integer primary key autoincrement, status int, start_time datetime, end_time datetime)";
			sqlite3_exec(_db, gamesTable.str().c_str(), NULL, 0, &zErrMsg);

			questionsTable << "create table t_questions(id intger primary key autoincrement, correctAnswer string, answer2 string, answer3 string, answer4 string)";
			sqlite3_exec(_db, questionsTable.str().c_str(), NULL, 0, &zErrMsg);
			
			usersTable << "create table t_users(username string primary key, password string, email string)";
			sqlite3_exec(_db, usersTable.str().c_str(), NULL, 0, &zErrMsg);
			
			playersAnswersTable << "create table t_players_answers(game_id integer primary key, username string primary key, question_id integer primary key, player_answer string, is_correct int, answer_time int, foreign key(game_id) REFERENCES games(id), foreign key(user_name) REFERENCES users(username), foreign key(question_id) REFERENCES questions(id))";
			sqlite3_exec(_db, playersAnswersTable.str().c_str(), NULL, 0, &zErrMsg);*/

			questionsTable << "create table t_questions(question_id int primary key,question string,correct_ans string,ans2 string,ans3 string,ans4 string)";
			sqlite3_exec(_db, questionsTable.str().c_str(), NULL, 0, &zErrMsg);
			
			gamesTable << "create table t_games(game_id int primary key,status int,start_time datetime,end_time datetime)";
			sqlite3_exec(_db, gamesTable.str().c_str(), NULL, 0, &zErrMsg);
			
			usersTable << "create table t_users(username string primary key,password string,email string)";
			sqlite3_exec(_db, usersTable.str().c_str(), NULL, 0, &zErrMsg);
			
			fk << "PRAGMA foreign_keys=1";
			sqlite3_exec(_db, fk.str().c_str(), NULL, 0, &zErrMsg);

			playersAnswersTable << "create table t_players_answers(game_id int, username string, question_id int, player_answer string, is_correct int, answer_time int, primary key(game_id, username, question_id), foreign key(game_id) REFERENCES t_games(game_id), foreign key(username) REFERENCES t_users(username), foreign key(question_id) REFERENCES t_questions(question_id))";
			sqlite3_exec(_db, playersAnswersTable.str().c_str(), NULL, 0, &zErrMsg);
		}

	}
	catch (exception& e)
	{
		cout << e.what() << endl;
	}
	
}

DataBase::~DataBase()
{
	sqlite3_close(this->_db);
	this->_db = nullptr;
}

bool DataBase::isUserExist(string username)
{
	int rc;
	bool returnedValue = true;

	stringstream showUsers;
	showUsers << "SELECT username from t_users WHERE username = " << '"' << username << '"';
	rc = sqlite3_exec(_db, showUsers.str().c_str(), callbackCount, 0, &zErrMsg);
	
	if (results.size() == 0)
	{
		return false;
	}
	results.clear();
	return returnedValue;
}

bool DataBase::addNewUser(string username, string password, string email)
{
	int rc;
	bool returnedValue = true;
	stringstream addingUser;

	addingUser << "insert into t_users values(" << '"' << username << '"' << ", " << '"' << password << '"' << ", " << '"' << email << '"' << ")";
	rc = sqlite3_exec(_db, addingUser.str().c_str(), NULL, 0, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		returnedValue = false;
	}

	return returnedValue;
}

bool DataBase::isUserAndPassMatch(string username, string password)
{
	int rc;
	stringstream getting;
	getting << "SELECT * FROM t_users WHERE username = " << '"' << username << '"' << " AND password = " << '"' << password << '"';
	rc = sqlite3_exec(_db, getting.str().c_str(), callbackCount, 0, &zErrMsg);
	
	if (results.size() == 0)
	{
		return false;
	}
	results.clear();

	return true;
}

string DataBase::restPassword(string username)
{
	stringstream restPassword;
	int rc;

	restPassword << "SELECT password from t_users WHERE username = " << '"' << username << '"';
	rc = sqlite3_exec(_db, restPassword.str().c_str(), callbackCount, 0, &zErrMsg);

	if (results.size() == 0)
	{
		return "";
	}
	string password = results["password"][0];
	results.clear();
	return password;
}

vector<Question*> DataBase::initQuestion(int numberOfQustions)
{
	vector<Question*> _questionsVector;
	srand(time(NULL));

	try
	{
		int questionCounter = 0;
		int rc;
		string question, correctAnswer, answer2, answer3, answer4;
		stringstream questions;

		questions << "Select * FROM t_questions";
		rc = sqlite3_exec(_db, questions.str().c_str(), callbackQuestions, 0, &zErrMsg);

		if (rc != SQLITE_OK)
		{
			throw exception(RETRIVING_ERROR);
		}
		else
		{
			for (questionCounter = 0; questionCounter < numberOfQustions; questionCounter++)
			{
				question = results["question"][questionCounter];
				correctAnswer = results["correct_ans"][questionCounter];
				answer2 = results["ans2"][questionCounter];
				answer3 = results["ans3"][questionCounter];
				answer4 = results["ans4"][questionCounter];

				Question* _question = new Question(questionCounter + 1, question, correctAnswer, answer2, answer3, answer4);
				_questionsVector.push_back(_question);
			}
		}
	}
	catch (exception& e)
	{
		cout << e.what() << endl;
		return _questionsVector;
	}
	return _questionsVector;
}

vector<string> DataBase::getBestScores()
{
	int rc;
	stringstream getIsCorrectQuestion;
	vector<string> _allOFPlayersWithIsCorrectAnswer;
	vector<string> _bestScoreUsernames;
	results.clear();

	try
	{
		// we have a vector of 
		getIsCorrectQuestion << "SELECT username from t_players_answers WHERE is_correct = 1";
		rc = sqlite3_exec(_db, getIsCorrectQuestion.str().c_str(), callbackBestScore, 0, &zErrMsg);
		
		if (rc != SQLITE_OK)
		{
			throw exception(RETRIVING_ERROR);
		}
		else
		{
			for (unsigned int i = 0; i < results["username"].size(); i++)
			{
				_allOFPlayersWithIsCorrectAnswer.push_back(results["username"][i]);
			}

			// string username, number of repetead time of the names
			map<string, int> usernamesCommon;
			map<string, int>::iterator it;

			for (unsigned int i = 0; i < results["username"].size(); i++)
			{
				usernamesCommon.insert(pair<string, int>(_allOFPlayersWithIsCorrectAnswer[i], 0));
				for (it = usernamesCommon.begin(); it != usernamesCommon.end(); ++it)
				{
					if (it->first == _allOFPlayersWithIsCorrectAnswer[i])
					{
						int c = usernamesCommon[it->first];
						usernamesCommon[it->first] = c + 1;
					}
				}
				
			}
			vector<std::pair<std::string, int>> topThree(3);
			partial_sort_copy(usernamesCommon.begin(), usernamesCommon.end(), topThree.begin(), topThree.end(),
				[](std::pair<const std::string, int> const& l,
					std::pair<const std::string, int> const& r)
			{
				return l.second > r.second;
			});

			vector<stringstream> names(3);
			names[0] << topThree[0].first << " " << theHelp.getPaddedNumber(topThree[0].second, 6);
			names[1] << topThree[1].first << " " << theHelp.getPaddedNumber(topThree[1].second, 6);
			names[2] << topThree[2].first << " " << theHelp.getPaddedNumber(topThree[2].second, 6);

			try
			{
				_bestScoreUsernames.push_back(names[0].str());
				_bestScoreUsernames.push_back(names[1].str());
				_bestScoreUsernames.push_back(names[2].str());
			}
			catch (exception& e)
			{
				cout << e.what() << endl;
			}
			
			return _bestScoreUsernames;
		}

	}
	catch (exception& e)
	{
		cout << e.what() << endl;
		return _bestScoreUsernames;
	}
	return _bestScoreUsernames;
}

vector<string> DataBase::getPersonalStatus(string username)
{
	vector<string> personalStatus;

	stringstream getNumberOfGames, AnswersNumber, numberOfWrongAnswers, avgTimeForAnswers;
	int rc;
	int gamesCount = 0, correctAnswerCount = 0, wrongAnswerCount = 0;
	string timeAvg = "";

	try
	{
		getNumberOfGames << "SELECT * from t_players_answers WHERE username = " << '"' << username << '"';
		rc = sqlite3_exec(_db, getNumberOfGames.str().c_str(), callbackPersonalStatus, 0, &zErrMsg);
		
		gamesCount = results["game_id"].size();

		if (gamesCount > 0)
		{
			AnswersNumber << "SELECT username from t_players_answers WHERE username = " << '"' << username << '"';
			rc = sqlite3_exec(_db, AnswersNumber.str().c_str(), callbackPersonalStatus, 0, &zErrMsg);

			for (unsigned int i = 0; i < results["is_correct"].size(); i++)
			{
				if (results["is_correct"][i] == "1")
				{
					correctAnswerCount++;
				}
				else
				{
					wrongAnswerCount++;
				}
			}

			avgTimeForAnswers << "SELECT AVG(answer_time) from t_players_answers WHERE username = " << '"' << username << '"';
			rc = sqlite3_exec(_db, avgTimeForAnswers.str().c_str(), callbackPersonalStatus, 0, &zErrMsg);
			timeAvg = results["AVG(answer_time)"][0].substr(0, 4);
		}
		else
		{
			correctAnswerCount = 0;
			wrongAnswerCount = 0;
			timeAvg = "0";
		}
		personalStatus.push_back(std::to_string(gamesCount));
		personalStatus.push_back(std::to_string(correctAnswerCount));
		personalStatus.push_back(std::to_string(wrongAnswerCount));
		personalStatus.push_back(timeAvg);
	}

	catch (exception& e)
	{
		cout << e.what() << endl;
		return personalStatus;
	}

	return vector<string>(personalStatus);
}

int DataBase::insertNewGame()
{
	int rc;
	
	time_t timeNow = time(0);
	string date = ctime(&timeNow);
	string status = "0";
	stringstream addingNewGame;
	
	addingNewGame << "INSERT into t_games(status, start_time, end_time) VALUES(" << '"' << status << '"' << ", " << '"' << date << '"' << ", " << "NULL)";

	try
	{
		rc = sqlite3_exec(_db, addingNewGame.str().c_str(), NULL, 0, &zErrMsg);
		if (rc != SQLITE_OK)
		{
			return -1;
		}

		else
		{
			this->_currentGameID++;
			return this->_currentGameID;
		}

	}
	catch (exception &e)
	{
		cout << e.what() << endl;
	}

	return _currentGameID;
}

bool DataBase::updateGameStatus(int gameID)
{
	int rc;
	time_t timeNow = time(0);
	//string date = ctime(&timeNow);
	string status = "1";
	
	stringstream updateGameStatus;
	updateGameStatus << "UPDATE t_games SET status = " << '"' <<  status << ", end_time = datetime('now')" << " WHERE game_id = " << '"' << std::to_string(gameID) << '"';

	try
	{
		rc = sqlite3_exec(_db, updateGameStatus.str().c_str(), nullptr, nullptr, &zErrMsg);
	
		if (rc != 1)
		{
			throw exception(UPDATING_ERROR);
			return false;
		}
	}
	catch (exception& e)
	{
		cout << e.what() << endl;
	}

	return true;
}

bool DataBase::addAnswerToPlayer(int gameID, string username, int questionID, string answer, bool isCorrect, int answerTime)
{
	int rc;
	stringstream addAnswerToPlayers;
	addAnswerToPlayers << "INSERT into t_players(game_id, username, question_id, player_answer, is_correct, answer_time) values("  << std::to_string(gameID)  << ", " << '"' << username << '"' << ", "  << std::to_string(questionID)  << ", " << '"' << answer << '"' << ", " << std::to_string(isCorrect) << ", " << std::to_string(answerTime) << ")";

	try
	{
		rc = sqlite3_exec(_db, addAnswerToPlayers.str().c_str(), NULL, 0, &zErrMsg);
		if (rc != SQLITE_OK)
		{
			throw exception(INSERTING_ERROR);
			return false;
		}
		else
		{
			return true;
		}
	}
	catch (exception& e)
	{
		cout << e.what() << endl;
	}

	return true;
}

int DataBase::callbackCount(void* notUsed, int argc, char** argv, char** azCol)
{
	int i;

	for (i = 0; i < argc; i++)
	{
		auto it = results.find(azCol[i]);
		if (it != results.end())
		{
			it->second.push_back(argv[i]);
		}
		else
		{
			pair<string, vector<string>> p;
			p.first = azCol[i];
			p.second.push_back(argv[i]);
			results.insert(p);
		}
	}

	return 0;
}

int DataBase::callbackQuestions(void* notUsed, int argc, char** argv, char** azCol)
{
	int i;

	for (i = 0; i < argc; i++)
	{
		auto it = results.find(azCol[i]);
		if (it != results.end())
		{
			it->second.push_back(argv[i]);
		}
		else
		{
			pair<string, vector<string>> p;
			p.first = azCol[i];
			p.second.push_back(argv[i]);
			results.insert(p);
		}
	}

	return 0;
}

int DataBase::callbackBestScore(void* notUsed, int argc, char** argv, char** azCol)
{
	int i;

	for (i = 0; i < argc; i++)
	{
		auto it = results.find(azCol[i]);
		if (it != results.end())
		{
			it->second.push_back(argv[i]);
		}
		else
		{
			pair<string, vector<string>> p;
			p.first = azCol[i];
			p.second.push_back(argv[i]);
			results.insert(p);
		}
	}

	return 0;
}

int DataBase::callbackPersonalStatus(void* notUsed, int argc, char** argv, char** azCol)
{
	int i;

	for (i = 0; i < argc; i++)
	{
		auto it = results.find(azCol[i]);
		if (it != results.end())
		{
			it->second.push_back(argv[i]);
		}
		else
		{
			pair<string, vector<string>> p;
			p.first = azCol[i];
			p.second.push_back(argv[i]);
			results.insert(p);
		}
	}

	return 0;
}
