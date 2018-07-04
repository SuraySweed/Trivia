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
    public partial class JoinRoomForm : Form
    {
        Form1 _mainForm = new Form1();
        Dictionary<string, string> rooms = new Dictionary<string, string>();

        public JoinRoomForm(ref Form1 mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void RoomsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            JoinButton.Enabled = true;

            List<string> UsersInRoom = new List<string>();
            string roomID = rooms.FirstOrDefault(x => x.Value == RoomsList.SelectedItem).Key;

            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.GetUsersInRoom(roomID));
            UsersInRoom = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

            UsersText.Visible = true;
            if (!(UsersInRoom is null))
            {
                foreach (string user in UsersInRoom)
                {
                    UsersInRoomList.Items.Add(user);
                }
            }

            UsersInRoomList.Visible = true;
        }

        private void JoinRoomForm_Load(object sender, EventArgs e)
        {
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.GetRooms());
            rooms = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

            foreach (KeyValuePair<string, string> room in rooms)
            {
                RoomsList.Items.Add(room.Value);
            }

            JoinButton.Enabled = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainForm.Show();
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            string roomID = rooms.FirstOrDefault(x => x.Value == RoomsList.SelectedItem).Key;
            List<int> numOfQuestionsAndQuestionTime = new List<int>();

            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.JoinRoom(roomID));
            numOfQuestionsAndQuestionTime = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

            
            Form1 f = _mainForm as Form1;
            WaitingForGame waitingForGame = new WaitingForGame(ref f, roomID, numOfQuestionsAndQuestionTime);

            waitingForGame.Show();
            this.Close();
        }
    }
}
