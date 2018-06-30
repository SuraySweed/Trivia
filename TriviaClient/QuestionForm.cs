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

        public QuestionForm(Form1 mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _mainForm.TriviaServerConnection.SendToServer(_mainForm.MyProtocol.LeaveGame());
            _mainForm.handleRecievedMessage(_mainForm.TriviaServerConnection.ReceiveFromServer());
        }
    }
}
