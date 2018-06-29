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
    public partial class ForgotPassword : Form
    {
        Form1 _mainForm;
        public ForgotPassword(ref Form1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void UserNameText_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainForm.Show();
        }

        private void Rest_Button_Click(object sender, EventArgs e)
        {
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.GetPassword(UserNameText.Text.ToString()));
            string msgFromServer = _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());

            AnsFromDataBase.Text = msgFromServer;
        }
    }
}
