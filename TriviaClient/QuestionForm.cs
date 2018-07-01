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
    public partial class QuestionForm : Form
    {
        Form1 _mainForm = new Form1();
        List<string> _questionsAndAnwers;
        string _timeToAnswer;
        string _numOfQuestions;

        public QuestionForm(ref Form1 mainForm, List<string> QuestionAndAnswers, string timeToAns, string numOfQuestion)
        {
            _mainForm = mainForm;
            _questionsAndAnwers = QuestionAndAnswers;
            _timeToAnswer = timeToAns;
            _numOfQuestions = numOfQuestion;

            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.LeaveGame());
            _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

            this.Close();
            _mainForm.Show();
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            int _NumOfQuestion = 1;

            for (int i = 0; i < Int32.Parse(_numOfQuestions); i++)
            {
                TimeLeft.Text = _timeToAnswer;

                NumOfQuestion.Text = "Question #" + _NumOfQuestion.ToString();

                Question.Text = _questionsAndAnwers[0];
                Ans1Button.Text = _questionsAndAnwers[1];
                Ans2Button.Text = _questionsAndAnwers[2];
                Ans3Button.Text = _questionsAndAnwers[3];
                Ans4Button.Text = _questionsAndAnwers[4];

                _NumOfQuestion++;

                _questionsAndAnwers = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());
            }
        }

        private void Ans1Button_Click(object sender, EventArgs e)
        {
            int time = Int32.Parse(_timeToAnswer) - Int32.Parse(TimeLeft.Text);
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.sendAnswer("1", time.ToString()));

            if (_mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer()))
            {
                Ans1Button.BackColor = Color.LightGreen;
            }
            else
            {
                Ans1Button.BackColor = Color.Red;
            }
        }

        private void Ans2Button_Click(object sender, EventArgs e)
        {
            int time = Int32.Parse(_timeToAnswer) - Int32.Parse(TimeLeft.Text);
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.sendAnswer("2", time.ToString()));

            if (_mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer()))
            {
                Ans2Button.BackColor = Color.LightGreen;
            }
            else
            {
                Ans2Button.BackColor = Color.Red;
            }
        }

        private void Ans3Button_Click(object sender, EventArgs e)
        {
            int time = Int32.Parse(_timeToAnswer) - Int32.Parse(TimeLeft.Text);
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.sendAnswer("3", time.ToString()));

            if (_mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer()))
            {
                Ans3Button.BackColor = Color.LightGreen;
            }
            else
            {
                Ans3Button.BackColor = Color.Red;
            }
        }

        private void Ans4Button_Click(object sender, EventArgs e)
        {
            int time = Int32.Parse(_timeToAnswer) - Int32.Parse(TimeLeft.Text);
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.sendAnswer("4", time.ToString()));

            if (_mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer()))
            {
                Ans4Button.BackColor = Color.LightGreen;
            }
            else
            {
                Ans4Button.BackColor = Color.Red;
            }
        }
    }
}
