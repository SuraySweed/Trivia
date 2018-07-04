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
    public partial class WaitingForGame : Form
    {
        Form1 _mainForm = new Form1();
        string _roomID;
        List<int> _numOfQuestionsAndQuestionTime = new List<int>();

        public WaitingForGame(ref Form1 mainForm, string roomID, List<int> numOfQuestionsAndQuestionTime)
        {
            _mainForm = mainForm;
            _roomID = roomID;
            _numOfQuestionsAndQuestionTime = numOfQuestionsAndQuestionTime;

            InitializeComponent();
        }

        private void WaitingForGame_Load(object sender, EventArgs e)
        {
            List<string> UsersInRoom = new List<string>();

            //_mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.GetUsersInRoom(_roomID));
            UsersInRoom = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

            if (!(UsersInRoom is null))
            {
                foreach (string user in UsersInRoom)
                {
                    NamesList.Items.Add(user);
                }
            }

            List<string> questionWithAnswersList = new List<string>();

            questionWithAnswersList = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

            Form1 f = _mainForm as Form1;
            QuestionForm questionForm = new QuestionForm(ref f, questionWithAnswersList, _numOfQuestionsAndQuestionTime[1].ToString(), _numOfQuestionsAndQuestionTime[0].ToString());

            //questionForm.NameOfUser.Text = NameOfUser.Text;
            questionForm.Show();
            this.Close();
        }

        private void LeaveRoomButton_Click(object sender, EventArgs e)
        {
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.LeaveRoom());

            if(_mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer()))
            {
                _mainForm.Show();
                this.Close();
            }
        }
    }
}
