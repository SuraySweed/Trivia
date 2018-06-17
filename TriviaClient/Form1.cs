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
        ClientServerSocket TriviaServerConnection = new ClientServerSocket();

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
            this.Close();
        }

        private void User_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_Text_TextChanged(object sender, EventArgs e)
        {

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

            if(client.Connected)
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
        //requests
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
