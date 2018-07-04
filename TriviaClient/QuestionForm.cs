using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        int _currentQuestion = 1;
        int _score = 0;

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
            ScoreText.Text = _score.ToString();
            getFirstQuestion();
        }

        private void getFirstQuestion()
        {
            TimeLeft.Text = _timeToAnswer;

            NumOfQuestion.Text = "Question #" + _currentQuestion.ToString();

            Question.Text = _questionsAndAnwers[0];
            Ans1Button.Text = _questionsAndAnwers[1];
            Ans2Button.Text = _questionsAndAnwers[2];
            Ans3Button.Text = _questionsAndAnwers[3];
            Ans4Button.Text = _questionsAndAnwers[4];
        }

        private void getNextQuestion() 
        {
            if ((_currentQuestion - 1) == Int32.Parse(_numOfQuestions))
            {
                Dictionary<string, int> scores = new Dictionary<string, int>();

                //_mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.LeaveGame());
                
                scores = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

                string messageToShow = "";

                foreach (KeyValuePair<string, int> user in scores)
                {
                    messageToShow += "User: " + user.Key + " Score: " + user.Value + "\n";
                }

                MessageBox.Show(messageToShow);
                

                this.Close();
                _mainForm.Show();
            }
            else
            {
                Ans1Button.BackColor = Color.SteelBlue;
                Ans2Button.BackColor = Color.SteelBlue;
                Ans3Button.BackColor = Color.SteelBlue;
                Ans4Button.BackColor = Color.SteelBlue;

                _questionsAndAnwers = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

                TimeLeft.Text = _timeToAnswer;

                NumOfQuestion.Text = "Question #" + _currentQuestion.ToString();

                Question.Text = _questionsAndAnwers[0];
                Ans1Button.Text = _questionsAndAnwers[1];
                Ans2Button.Text = _questionsAndAnwers[2];
                Ans3Button.Text = _questionsAndAnwers[3];
                Ans4Button.Text = _questionsAndAnwers[4];

                _currentQuestion++;
            }
        }

        private void Ans1Button_Click(object sender, EventArgs e)
        {

            int time = Int32.Parse(_timeToAnswer) - Int32.Parse(TimeLeft.Text);
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.sendAnswer("1", time.ToString()));

            if (_mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer()))
            {
                Ans1Button.BackColor = Color.LightGreen;
                ScoreText.Text = (_score++).ToString();
            }
            else
            {
                Ans1Button.BackColor = Color.Red;
            }
            if (_currentQuestion != Int32.Parse(_numOfQuestions))
            {
                getNextQuestion();
                
            }

        }

        private void Ans2Button_Click(object sender, EventArgs e)
        {

            int time = Int32.Parse(_timeToAnswer) - Int32.Parse(TimeLeft.Text);
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.sendAnswer("2", time.ToString()));

            if (_mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer()))
            {
                Ans2Button.BackColor = Color.LightGreen;
                ScoreText.Text = (_score++).ToString();
            }
            else
            {
                Ans2Button.BackColor = Color.Red;
            }
            if (_currentQuestion != Int32.Parse(_numOfQuestions))
            {
                getNextQuestion();
                
            }

        }

        private void Ans3Button_Click(object sender, EventArgs e)
        {
            int time = Int32.Parse(_timeToAnswer) - Int32.Parse(TimeLeft.Text);
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.sendAnswer("3", time.ToString()));

            if (_mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer()))
            {
                Ans3Button.BackColor = Color.LightGreen;
                ScoreText.Text = (_score++).ToString();
            }
            else
            {
                Ans3Button.BackColor = Color.Red;
            }
            if (_currentQuestion != Int32.Parse(_numOfQuestions))
            {
                getNextQuestion();
            }

        }

        private void Ans4Button_Click(object sender, EventArgs e)
        {

            int time = Int32.Parse(_timeToAnswer) - Int32.Parse(TimeLeft.Text);
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.sendAnswer("4", time.ToString()));

            if (_mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer()))
            {
                Ans4Button.BackColor = Color.LightGreen;
                ScoreText.Text = (_score++).ToString();
            }
            else
            {
                Ans4Button.BackColor = Color.Red;
            }
            if (_currentQuestion != Int32.Parse(_numOfQuestions))
            {
                getNextQuestion();
            }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            TimeLeft.Text = (Int32.Parse(TimeLeft.Text) - 1).ToString();

            if (TimeLeft.Text == "0")
            {
                
                if (_currentQuestion == Int32.Parse(_numOfQuestions))
                {
                    Dictionary<string, int> scores = new Dictionary<string, int>();

                    //_mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.LeaveGame());

                    scores = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

                    string messageToShow = "";

                    foreach (KeyValuePair<string, int> user in scores)
                    {
                        messageToShow += "User: " + user.Key + " Score: " + user.Value + "\n";
                    }

                    MessageBox.Show(messageToShow);
                    timer1.Enabled = false;

                    this.Close();
                    _mainForm.Show();
                }
                else
                {
                    int time = Int32.Parse(_timeToAnswer) - Int32.Parse(TimeLeft.Text);
                    _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.sendAnswer("5", time.ToString()));

                   dynamic somthing =  _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

                    getNextQuestion();
                }
            }
            



        }
    }
}
