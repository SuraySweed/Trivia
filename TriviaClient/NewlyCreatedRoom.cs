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
        public NewlyCreatedRoom(ref Form1 main_form)
        {
            _mainForm = main_form;
            InitializeComponent();
            
        }

        private void NewlyCreatedRoom_Load(object sender, EventArgs e)
        {
            NamesList.Items.Add(NameOfUser.Text);
            
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
    }
}
