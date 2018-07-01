using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTriviaClient
{
    public partial class CreateRoomForm : Form
    {
        Form1 _mainForm = new Form1();
        public CreateRoomForm(ref Form1 main_form)
        {
            _mainForm = main_form;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainForm.Show();
        }

        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            string roomName = Room_Name_text.Text;
            string playersNum = Num_Of_Players.Text;
            string questionsNum = Num_Of_Questions.Text;
            string timeForQuestion = Time_For_Questions.Text;

            string msgToSend = _mainForm.MyProtocol.CreateRoom(roomName, playersNum, questionsNum, timeForQuestion);

            _mainForm.TriviaServerConnection.SendToServer(msgToSend);

            if(_mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer()))
            {
                string roomID;

                _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.GetRooms());

                Dictionary<string, string> Rooms = new Dictionary<string, string>();
                Rooms = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());
                roomID = Rooms.FirstOrDefault(x => x.Value == roomName).Key;


                Form1 f = _mainForm as Form1;
                NewlyCreatedRoom newlyCreatedRoom = new NewlyCreatedRoom(ref f, roomID, timeForQuestion, questionsNum);
                newlyCreatedRoom.NameOfUser.Text = NameOfUser.Text;
                
                newlyCreatedRoom.Show();
               
                this.Close();
            }
            else
            {
                MessageBox.Show("We have a problem creating your room!");
                this.Close();
                _mainForm.Show();
            }
        }

        private void CreateRoomForm_Load(object sender, EventArgs e)
        {

        }
    }
}
