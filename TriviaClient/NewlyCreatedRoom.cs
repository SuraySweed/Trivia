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
    public partial class NewlyCreatedRoom : Form
    {
        Form1 _mainForm = new Form1();
        string _roomID;
        string _timeForAnswer;
        string _numOfQuestions;

        public NewlyCreatedRoom(ref Form1 main_form, string roomID, string TimeforAns, string numOfQuestions)
        {
            _mainForm = main_form;
            _roomID = roomID;
            _timeForAnswer = TimeforAns;
            _numOfQuestions = numOfQuestions;

            InitializeComponent();
            
        }

        private void NewlyCreatedRoom_Load(object sender, EventArgs e)
        {
            List<string> UsersInRoom = new List<string>();

            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.GetUsersInRoom(_roomID));
            UsersInRoom = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());
            if (!(UsersInRoom is null))
            {
                foreach (string user in UsersInRoom) 
                {
                    NamesList.Items.Add(user);
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e) // close button
        {
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.CloseRoom());
            _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());
            this.Close();
            _mainForm.Show();
        }

        private void NamesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NamesList_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            List<string> questionAndAnswers = new List<string>();
            List<string> Users = new List<string>();

            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.StartGame());
            Users = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());
            questionAndAnswers = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

            Form1 f = _mainForm as Form1;
            QuestionForm questionForm = new QuestionForm(ref f, questionAndAnswers, _timeForAnswer, _numOfQuestions);
            questionForm.NameOfUser.Text = NameOfUser.Text;
            questionForm.Show();
            this.Hide();
             

        }
    }
}
