using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTriviaClient
{
    class BuildMessage
    {
        private string messageToSend;
        public string SignIn(string username, string password)
        {
            messageToSend = "200" + username.Length.ToString() + username + password.Length.ToString() + password;
            return messageToSend;
        }
        public string SignOut()
        {
            messageToSend = "201";
            return messageToSend;
        }

        public string SignUp(string username, string password, string email)
        {
            messageToSend = "203" + username.Length.ToString() + username + password.Length.ToString() + password + email.Length.ToString() + email;
            return messageToSend;
        }

        public string GetRooms()
        {
            messageToSend = "205";
            return messageToSend;
        }

        public string GetUsersInRoom(string roomID)
        {
            messageToSend = "207" + roomID;
            return messageToSend;
        }

        public string JoinRoom(string roomID)
        {
            messageToSend = "209" + roomID;
            return messageToSend;
        }

        public string LeaveRoom()
        {
            messageToSend = "211";
            return messageToSend;
        }

        public string CreateRoom(string roomName, string playersNumber, string questionsNumber, string questionTimeInSec)
        {
            messageToSend = "213" + roomName.Length.ToString() + roomName + playersNumber + questionsNumber + questionTimeInSec;
            return messageToSend;
        }

        public string CloseRoom()
        {
            messageToSend = "215";
            return messageToSend;
        }

        public string StartGame()
        {
            messageToSend = "217";
            return messageToSend;
        }

        public string sendAnswer(string answerNumber, string time)
        {
            messageToSend = "219" + answerNumber + time;
            return messageToSend;
        }

        public string LeaveGame()
        {
            messageToSend = "222";
            return messageToSend;
        }

        public string GetBestScore()
        {
            messageToSend = "223";
            return messageToSend;
        }

        public string GetPersonalScore()
        {
            messageToSend = "225";
            return messageToSend;
        }
        public string LeaveApp()
        {
            messageToSend = "299";
            return messageToSend;
        }
    }

    public class MessageCodes
    {
        public const int SIGN_IN = 200;
        public const int SIGN_OUT = 201;
        public const int SIGN_UP = 203;
        public const int GET_ROOMS = 205;
        public const int GET_USERS_IN_ROOM = 207;
        public const int JOIN_ROOM = 209;
        public const int LEAVE_ROOM = 211;
        public const int CREATE_ROOM = 213;
        public const int CLOSE_ROOM = 215;
        public const int START_GAME = 217;
        public const int SEND_YOUR_ANSWER = 219;
        public const int LEAVE_GAME = 222;
        public const int GET_BEST_SCORES = 223;
        public const int GET_PERSONAL_STATUS = 225;
        public const int LEAVE_APP = 299;
    }

   
}
