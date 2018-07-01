using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Collections;
using System.Globalization;
using System.Resources;

namespace NewTriviaClient
{
    public partial class Form1 : Form
    {
        public Protocol MyProtocol = new Protocol();
        public ClientServerSocket TriviaServerConnection = new ClientServerSocket();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool check = true;

            while (check)
            {
                check = TriviaServerConnection.connection();
                if (check)
                {
                    break;
                }
                else
                {
                    ErrorForm error = new ErrorForm();
                    error.Show();
                    this.Hide();
                }
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BackPic1.Top--;
            if (BackPic1.Bottom <= 0)
            {
                BackPic1.Top = this.ClientRectangle.Bottom;
            }

            BackPic2.Top--;
            if (BackPic2.Bottom <= 0)
            {
                BackPic2.Top = this.ClientRectangle.Bottom;
            }

            BackPic3.Top--;
            if (BackPic3.Bottom <= 0)
            {
                BackPic3.Top = this.ClientRectangle.Bottom;
            }

            BackPic4.Top--;
            if (BackPic4.Bottom <= 0)
            {
                BackPic4.Top = this.ClientRectangle.Bottom;
            }

            BackPic5.Top--;
            if (BackPic5.Bottom <= 0)
            {
                BackPic5.Top = this.ClientRectangle.Bottom;
            }


            BackPic6.Top--;
            if (BackPic6.Bottom <= 0)
            {
                BackPic6.Top = this.ClientRectangle.Bottom;
            }

            BackPic7.Top--;
            if (BackPic7.Bottom <= 0)
            {
                BackPic7.Top = this.ClientRectangle.Bottom;
            }

            BackPic8.Top--;
            if (BackPic8.Bottom <= 0)
            {
                BackPic8.Top = this.ClientRectangle.Bottom;
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            TriviaServerConnection.SendToServer(MyProtocol.LeaveApp());
            this.Close();
        }

        private void User_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_Text_TextChanged(object sender, EventArgs e)
        {
            Password_Text.UseSystemPasswordChar = true;
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            string username = User_Name.Text;
            string password = Password_Text.Text;

            string msgToSend = MyProtocol.SignIn(username, password);
            TriviaServerConnection.SendToServer(msgToSend);

            handleRecievedMessage(TriviaServerConnection.ReceiveFromServer());
        }

        public dynamic handleRecievedMessage(string MsgFromServer)
        {
            int msgCode = Int32.Parse(MsgFromServer.Substring(0, 3));

            if (msgCode == 0)
            {
                // nothing it just connected
            }
            else if (msgCode == ServerCodes.SIGN_IN)
            {
                int status = Int32.Parse(MsgFromServer[3].ToString());
                switch (status)
                {
                    case 0:
                        // success
                        popUpText.Text = "";

                        this.UserName.Hide();
                        this.User_Name.Hide();
                        this.Password.Hide();
                        this.Password_Text.Hide();
                        this.SignInButton.Hide();
                        this.Show_Password.Hide();
                        this.Forgot_Password.Hide();
                        this.HelloUserLabel.Text = "Hello " + User_Name.Text;
                        this.HelloUserLabel.Show();

                        this.SignUpButton.Hide();

                        this.CreateRoomButton.Enabled = true;
                        this.JoinRoomButton.Enabled = true;
                        this.MyStatusButton.Enabled = true;
                        this.BestScoresButton.Enabled = true;
                        this.SignOutButton.Enabled = true;

                        SignOutButton.Show();

                        break;
                    case 1:
                        // TO DO : MNADE LL DSPLE
                        popUpText.Text = "Wrong Details..";

                        break;
                    case 2:
                        // is aleardy connected
                        popUpText.Text = "this user is already signed in!!";
                        break;

                }
                return null;
            }
            else if (msgCode == ServerCodes.SIGN_UP)
            {
                int status = Int32.Parse(MsgFromServer[3].ToString());

                switch (status)
                {
                    case 0:
                        return "YOU ARE NOW REGESTURED";
                        break;
                    case 1:
                        return "Illegal Pass";
                        break;
                    case 2:
                        return "Username Already Exists!!";
                        break;
                    case 3:
                        return "Username is Illegal!!";
                        break;
                    case 4:
                        return "No Clue what the problem is!!";
                        break;
                }
                return null;
            }
            else if (msgCode == ServerCodes.GET_FORGOT_PASSWORD)
            {
                int isFound = Int32.Parse(MsgFromServer[3].ToString());

                if (isFound == 1)
                {
                    int passwordLength = Int32.Parse(MsgFromServer.Substring(4, 4));
                    string password = MsgFromServer.Substring(8, passwordLength);

                    return "User is Found.!, Password : " + password;
                }
                else
                {
                    return "User not found in the DATABASE.!";
                }
                return null;
            }

            else if (msgCode == ServerCodes.SEND_ROOMS_LIST)
            {
                int numOfRooms = Int32.Parse(MsgFromServer.Substring(3, 4));
                // rooms <id, name>
                Dictionary<string, string> Rooms = new Dictionary<string, string>();

                int firstRoomIDIndex = 7;
                int firstRoomNameSizeIndex = 11;
                string roomID;
                int roomNameSize = 0;
                string roomName;
                int roomNameSizeSum = 0;

                for (int i = 0; i < numOfRooms; i++)
                {
                    roomNameSize = Int32.Parse(MsgFromServer.Substring(firstRoomNameSizeIndex + roomNameSizeSum + i * 4 + i * 2, 2));

                    roomName = MsgFromServer.Substring(firstRoomNameSizeIndex + 2 + roomNameSizeSum + i * 4 + i * 2, roomNameSize);
                    roomID = MsgFromServer.Substring(firstRoomIDIndex + i * 4 + i * 2 + roomNameSizeSum, 4);
                    roomNameSizeSum += roomNameSize;
                    Rooms.Add(roomID, roomName);
                }

                return Rooms;
                // Send Dict in Function

            }
            else if (msgCode == ServerCodes.SEND_USERS_LIST)
            {
                int numOfUsers = Int32.Parse(MsgFromServer.Substring(3, 3));
                if (numOfUsers == 0)
                {

                }
                else
                {
                    List<string> Users = new List<string>();

                    int firstUserNameSizeIndex = 6;
                    string userName;
                    int NameSize;
                    int NameSizeSum = 0;

                    for (int i = 0; i < numOfUsers; i++)
                    {
                        NameSize = Int32.Parse(MsgFromServer.Substring(firstUserNameSizeIndex + NameSizeSum + i * 2, 2));

                        userName = MsgFromServer.Substring(firstUserNameSizeIndex + 2 + NameSizeSum + 2 * i, NameSize);
                        NameSizeSum += NameSize;

                        Users.Add(userName);
                    }

                    return Users;// Send usernames list to the function

                }
            }
            else if (msgCode == ServerCodes.RESPOND_TO_JOIN_ROOM)
            {
                int status = Int32.Parse(MsgFromServer[4].ToString());
                switch (status)
                {
                    case 0: // success
                        List<int> list = new List<int>();

                        int numOfQuestions = Int32.Parse(MsgFromServer.Substring(4, 2));
                        int QuestionTimeInSec = Int32.Parse(MsgFromServer.Substring(6, 2));

                        list.Add(numOfQuestions);
                        list.Add(QuestionTimeInSec);

                        return list;

                        break;
                    case 1: // room is full

                        break;
                    case 2: // room doesn't exsist or somthing like that

                        break;
                }
                return null;
            }
            else if (msgCode == ServerCodes.RESPOND_TO_LEAVE_ROOM)
            {
                return null;
            }
            else if (msgCode == ServerCodes.RESPOND_TO_CREATE_ROOM)
            {
                int status = Int32.Parse(MsgFromServer[3].ToString());

                switch (status)
                {
                    case 0: // success
                        return true;
                        break;
                    case 1: // fail
                        return false;
                        break;
                }
                return null;
            }
            else if (msgCode == ServerCodes.RESPOND_TO_CLOSE_ROOM)
            {
                return null;
            }
            else if (msgCode == ServerCodes.RESPOND_TO_QUESTION_WITH_ANSWERS) // start game
            {
                List<string> questionWithAnswersList = new List<string>();
                int sizeSum = 0;

                int QuestionSize = Int32.Parse(MsgFromServer.Substring(3, 3));
                string Question = MsgFromServer.Substring(6, QuestionSize);

                sizeSum += QuestionSize;

                int ans1Size = Int32.Parse(MsgFromServer.Substring(6 + sizeSum, 3));
                string ans1 = MsgFromServer.Substring(6 + 3 + sizeSum, ans1Size);

                sizeSum += ans1Size;

                int ans2Size = Int32.Parse(MsgFromServer.Substring(6 + sizeSum, 3)); //problem
                string ans2 = MsgFromServer.Substring(6 + 3 + sizeSum, ans2Size);

                sizeSum += ans2Size;

                int ans3Size = Int32.Parse(MsgFromServer.Substring(6 + sizeSum, 3));
                string ans3 = MsgFromServer.Substring(6 + 3 + sizeSum, ans3Size);

                sizeSum += ans3Size;

                int ans4Size = Int32.Parse(MsgFromServer.Substring(6 + sizeSum, 3));
                string ans4 = MsgFromServer.Substring(6 + 3 + sizeSum, ans4Size);

                sizeSum += ans4Size;

                questionWithAnswersList.Add(Question);
                questionWithAnswersList.Add(ans1);
                questionWithAnswersList.Add(ans2);
                questionWithAnswersList.Add(ans3);
                questionWithAnswersList.Add(ans4);

                return questionWithAnswersList;
            }
            else if (msgCode == ServerCodes.RESPOND_TO_USERS_ANS)
            {
                int status = Int32.Parse(MsgFromServer[4].ToString());

                switch (status)
                {
                    case 0: // correct answer
                        break;
                    case 1: // wrong answer
                        break;
                }
                return null;
            }
            else if (msgCode == ServerCodes.GAME_IS_FINISHED)
            {
                int numOfUsers = Int32.Parse(MsgFromServer.Substring(3, 1));

                if (numOfUsers == 0)
                {

                }
                else
                {
                    Dictionary<string, int> Users = new Dictionary<string, int>();

                    int firstUserNameSizeIndex = 4;
                    string userName;
                    int NameSize;
                    int sizeSum = 0;
                    int UserScore;

                    for (int i = 0; i < numOfUsers; i++)
                    {
                        NameSize = Int32.Parse(MsgFromServer.Substring(firstUserNameSizeIndex + sizeSum + i * 4, 2));
                        userName = MsgFromServer.Substring(firstUserNameSizeIndex + 2 + sizeSum + i * 4, NameSize);

                        sizeSum += NameSize;

                        UserScore = Int32.Parse(MsgFromServer.Substring(firstUserNameSizeIndex + 2 + sizeSum + i * 4, 2));

                        Users[userName] = UserScore;
                    }

                    return null;// Send usernames list to the function

                }
            }
            else if (msgCode == ServerCodes.GET_BEST_SCORES_FROM_SERVER)
            {
                Dictionary<string, int> Users = new Dictionary<string, int>();

                int firstUserNameSizeIndex = 3;
                string userName;
                int NameSize;
                int sizeSum = 0;
                int UserScore;

                for (int i = 0; i < 3; i++)
                {
                    NameSize = Int32.Parse(MsgFromServer.Substring(firstUserNameSizeIndex + sizeSum + 8 * i, 2));
                    userName = MsgFromServer.Substring(firstUserNameSizeIndex + 2 + sizeSum + i * 8, NameSize);

                    sizeSum += NameSize;

                    UserScore = Int32.Parse(MsgFromServer.Substring(firstUserNameSizeIndex + 2 + sizeSum + i * 8, 6));

                    Users[userName] = UserScore;
                }
                return Users;
            }
            else if (msgCode == ServerCodes.GET_PERSONAL_STATUS_FROM_SERVER)
            {
                int numberOfGames = Int32.Parse(MsgFromServer.Substring(3, 4));
                int numberOfRightAnswers;
                int numberOfWrongAnswers;
                float avgTimeForAnswer;

                 List<string> ans = new List<string>();

                if (numberOfGames == 0)
                {
                    //nvrmnd
                    numberOfRightAnswers = Int32.Parse(MsgFromServer.Substring(7, 6));
                    numberOfWrongAnswers = Int32.Parse(MsgFromServer.Substring(13, 6));
                    int tens = Int32.Parse(MsgFromServer.Substring(19, 1));
                    int ones = Int32.Parse(MsgFromServer.Substring(20, 1));
                    int tenth = Int32.Parse(MsgFromServer.Substring(21, 1));
                    int percent = Int32.Parse(MsgFromServer.Substring(22, 1));

                    avgTimeForAnswer = tens * 10 + ones * 1 + (float)(tenth * 0.1) + (float)(percent * 0.01);

                    ans.Add(numberOfGames.ToString());
                    ans.Add(numberOfRightAnswers.ToString());
                    ans.Add(numberOfWrongAnswers.ToString());
                    ans.Add(avgTimeForAnswer.ToString());
                }
                else
                {
                    numberOfRightAnswers = Int32.Parse(MsgFromServer.Substring(7, 6));
                    numberOfWrongAnswers = Int32.Parse(MsgFromServer.Substring(13, 6));
                    int tens = Int32.Parse(MsgFromServer.Substring(19, 1));
                    int ones = Int32.Parse(MsgFromServer.Substring(20, 1));
                    int tenth = Int32.Parse(MsgFromServer.Substring(21, 1));
                    int percent = Int32.Parse(MsgFromServer.Substring(22, 1));

                    avgTimeForAnswer = tens * 10 + ones * 1 + (float)(tenth * 0.1) + (float)(percent * 0.01);

                    ans.Add(numberOfGames.ToString());
                    ans.Add(numberOfRightAnswers.ToString());
                    ans.Add(numberOfWrongAnswers.ToString());
                    ans.Add(avgTimeForAnswer.ToString());
                }

               
                return ans;
            }
            return null;
        }

       
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = this as Form1;
            SignUp SignUpForm = new SignUp(ref f);

            SignUpForm.Show();
        }

        private void SignOutButton_Click(object sender, EventArgs e)
        {
            string msgToSend = MyProtocol.SignOut();

            TriviaServerConnection.SendToServer(msgToSend);

            this.UserName.Show();
            this.User_Name.Show();
            this.Password.Show();
            this.Password_Text.Show();
            this.Show_Password.Show();
            this.SignInButton.Show();
            this.Forgot_Password.Show();
            this.HelloUserLabel.Hide();

            this.SignUpButton.Show();
            SignOutButton.Hide();

            this.BestScoresButton.Enabled = false;
            this.MyStatusButton.Enabled = false;
            this.CreateRoomButton.Enabled = false;
            this.JoinRoomButton.Enabled = false;
        }

        private void MyStatusButton_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            string msgToSend = MyProtocol.GetPersonalScore();

            TriviaServerConnection.SendToServer(msgToSend);

            list = handleRecievedMessage(TriviaServerConnection.ReceiveFromServer());

            

            this.Hide();
            Form1 f = this as Form1;
            myStatusForm statusForm = new myStatusForm(ref f);

            statusForm.Show();
            statusForm.Status.Text = "Number of Games: " + list[0] + "\nNumber Of Right Answers: " + list[1] + "\nNumber Of Wrong Answers: " + list[2] + "\nAverage Time For Answer: " + list[3];

            statusForm.NameOfUser.Text = this.User_Name.Text;
        }

        private void BestScoresButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> BestScoreDict = new Dictionary<string, int>();

            string msgToSend = MyProtocol.GetBestScore();

            TriviaServerConnection.SendToServer(msgToSend);

            BestScoreDict = handleRecievedMessage(TriviaServerConnection.ReceiveFromServer());

            this.Hide();
            Form1 f = this as Form1;
            BestScoresForm bestScoreForm = new BestScoresForm(ref f);

            bestScoreForm.Show();

            foreach (KeyValuePair<string, int> kvp in BestScoreDict)
            {
                bestScoreForm.BestScoreText.Text += kvp.Key + " : " + kvp.Value + " PTS" + "\n\n";
            }        

            bestScoreForm.NameOfUser.Text = this.User_Name.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = this as Form1;

            CreateRoomForm createRoomForm = new CreateRoomForm(ref f);
            createRoomForm.Show();

            createRoomForm.NameOfUser.Text = this.User_Name.Text;
        }

        private void Show_Password_CheckedChanged(object sender, EventArgs e)
        {
            if (Show_Password.Checked)
            {
                Password_Text.UseSystemPasswordChar = false;
            }
            else
            {
                Password_Text.UseSystemPasswordChar = true;
            }
        }

        private void Forgot_Password_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = this as Form1;

            ForgotPassword createRoomForm = new ForgotPassword(ref f);
            createRoomForm.Show();
        }

        private void JoinRoomButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = this as Form1;

            JoinRoomForm joinRoomForm = new JoinRoomForm(ref f);

            joinRoomForm.NameOfUser.Text = this.User_Name.Text;
            joinRoomForm.Show();


        }
    }



    public class ClientServerSocket
    {
        private TcpClient client;
        private NetworkStream clientStream;

        public TcpClient getClient()
        {
            return client;
        }

        public bool connection()
        {
            try
            {
                client = new TcpClient();
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8820);
                client.Connect(serverEndPoint);
                clientStream = client.GetStream();
            }
            catch (Exception e)
            {

            }

            if (client.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SendToServer(string msgToServer)
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(msgToServer);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        public string ReceiveFromServer()
        {
            try
            {
                byte[] bufferln = new byte[4800];
                int bytesRead = clientStream.Read(bufferln, 0, 4800);
                string message = new ASCIIEncoding().GetString(bufferln);
                return message;
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection Error, " + e.ToString());
            }
            return "";
        }
    }

    public class Protocol
    {
        public string getPaddedNumber(int number, int numberOfDigits)
        {
            string toReturn = number.ToString();
            toReturn = toReturn.PadLeft(numberOfDigits, '0');
            return toReturn;
        }

        private string messageToSend;
        public string SignIn(string username, string password)
        {
            messageToSend = "200" + getPaddedNumber(username.Length, 2) + username + getPaddedNumber(password.Length, 2) + password;
            return messageToSend;
        }
        public string SignOut()
        {
            messageToSend = "201";
            return messageToSend;
        }

        public string SignUp(string username, string password, string email)
        {
            messageToSend = "203" + getPaddedNumber(username.Length, 2) + username + getPaddedNumber(password.Length, 2) + password + getPaddedNumber(email.Length, 2) + email;
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
            messageToSend = "213" + getPaddedNumber(roomName.Length, 2) + roomName + playersNumber + questionsNumber.PadLeft(2, '0') + questionTimeInSec.PadLeft(2, '0');
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
            messageToSend = "219" + answerNumber + time.PadLeft(2, '0');
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

        public string GetPassword(string username)
        {
            messageToSend = "227" + getPaddedNumber(username.Length, 4) + username;
            return messageToSend;
        }

        public string LeaveApp()
        {
            messageToSend = "299";
            return messageToSend;
        }
    }

    public class ServerCodes
    {
        public const int SIGN_IN = 102;
        public const int SIGN_UP = 104;
        public const int SEND_ROOMS_LIST = 106;
        public const int SEND_USERS_LIST = 108;
        public const int RESPOND_TO_JOIN_ROOM = 110;
        public const int RESPOND_TO_LEAVE_ROOM = 112;
        public const int RESPOND_TO_CREATE_ROOM = 114;
        public const int RESPOND_TO_CLOSE_ROOM = 116;
        public const int RESPOND_TO_QUESTION_WITH_ANSWERS = 118; // start game
        public const int RESPOND_TO_USERS_ANS = 120;
        public const int GAME_IS_FINISHED = 121;
        public const int GET_BEST_SCORES_FROM_SERVER = 124;
        public const int GET_PERSONAL_STATUS_FROM_SERVER = 126;
        public const int GET_FORGOT_PASSWORD = 127;
    }

   
}
