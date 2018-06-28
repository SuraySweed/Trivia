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
    public partial class SignUp : Form
    {
        Form1 _mainForm = new Form1();
        public SignUp(ref Form1 mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            string username = UserNameText.Text;
            string password = PasswordText.Text;
            string email = EmailText.Text;

            string msgToSend = _mainForm.MyProtocol.SignUp(username, password, email);

            _mainForm.TriviaServerConnection.SendToServer(msgToSend);

            string msgToShow = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

            popUpText.Text = msgToShow;

            if(msgToShow == "YOU ARE NOW REGESTURED")
            {
                this.Close();
                _mainForm.Show();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainForm.Show();
        }
    }
}
