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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            this.Close();
        }

        private void User_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_Text_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignInButton_Click(object sender, EventArgs e)
        {

        }

        private void handles(string MsgFromServer)
        {
            int msgCode = Int32.Parse(MsgFromServer.Substring(0, 3));

            if (msgCode == ServerCodes.SIGN_IN)
            {
                int status = Int32.Parse(MsgFromServer[3].ToString());
                switch (status)
                {
                    case 0:
                        // TO DO: MNADE LLHALON ALE B3D MEFOT 
                        break;
                    case 1:
                        // TO DO : MNADE LL DSPLE
                        popUpText.Text = "Wrong Details bra...";

                        break;
                    case 2:
                        // is aleardy connected
                        popUpText.Text = "this user is already signed in!!";
                        break;
                }
            }
            else if (msgCode == ServerCodes.SIGN_UP)
            {
                int status = Int32.Parse(MsgFromServer[3].ToString());

                switch (status)
                {
                    case 0:
                        // No Problem---- TODOSHIT
                        break;
                    case 1:
                        popUpText.Text = "Illegal Pass";
                        break;
                    case 2:
                        popUpText.Text = "Username Already Exists!!";
                        break;
                    case 3:
                        popUpText.Text = "Username is Illegal!!";
                        break;
                    case 4:
                        popUpText.Text = "No Clue what the problem is!!";
                        break;
                }
            }
            else if(msgCode == ServerCodes.SEND_ROOMS_LIST)
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

                // Send Dict in Function
                
            }
            else if(msgCode == ServerCodes.SEND_USERS_LIST)
            {
                int numOfUsers = Int32.Parse(MsgFromServer.Substring(3, 4));
                if (numOfUsers == 0)
                {

                }
                else
                {
                    List<string> Users = new List<string>();

                    int firstUserNameSizeIndex = 4;
                    string userName;
                    int NameSize;
                    int NameSizeSum = 0;

                    for (int i = 0; i < numOfUsers; i++) 
                    {
                        NameSize = Int32.Parse(MsgFromServer.Substring(firstUserNameSizeIndex + NameSizeSum + i*2, 2));

                        userName = MsgFromServer.Substring(firstUserNameSizeIndex + 2 + NameSizeSum + 2 * i, NameSize);
                        NameSizeSum += NameSize;

                        Users.Add(userName);
                    }

                    // Send usernames list to the function

                }
            }
            else if(msgCode == ServerCodes.RESPOND_TO_JOIN_ROOM) 
            {
                int status = Int32.Parse(MsgFromServer[4].ToString());
                switch(status)
                {
                    case 0: // success

                        int numOfQuestions = Int32.Parse(MsgFromServer.Substring(4, 2));
                        int QuestionTimeInSec = Int32.Parse(MsgFromServer.Substring(6, 2));

                        break;
                    case 1: // room is full

                        break;
                    case 2: // room doesn't exsist or somthing like that

                        break;
                }
            }
        }
        // [1100 questionsNumber questionTimeInSec] 

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            //test fuck = new test();
            //fuck.foo();
        }
    }
   

    public class ServerConnectionTCP
    {
        private TcpClient client;
        private NetworkStream clientStream;
        public ServerConnectionTCP()
        {
            client = new TcpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8820);
            client.Connect(serverEndPoint);
            clientStream = client.GetStream();
        }
        public void SendToServer(string msgToServer)
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(msgToServer);
            clientStream.Write(buffer, 0, 4);
            clientStream.Flush();
        }

        public string ReceiveFromServer()
        {
            try
            {
                byte[] bufferln = new byte[4];
                int bytesRead = clientStream.Read(bufferln, 0, 4);
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
        public String request200(String username, String password)
        {
            return "f";
        }
        /*
        String request201();
        String request203(String username, String password, String email);
        String request205();
        String request207(int roomID);
        String request209(int roomID);
        String request211();
        String request213(String roomName, int playersNumber, int questionsNumber, int time);
        String request215();
        String request217();
        String request219(int numberOfQuestion, int timeInSeconds);
        String request222();
        String request223();
        String request225();
        */
    }

    public class ServerCodes
    {
        //Sign In
        public const int SIGN_IN = 102;

        //Sign Up
        public const int SIGN_UP = 104;

        // send list of rooms
        public const int SEND_ROOMS_LIST = 106;

        // send list of users
        public const int SEND_USERS_LIST = 108;

        public const int RESPOND_TO_JOIN_ROOM = 110;
    }
    


}
