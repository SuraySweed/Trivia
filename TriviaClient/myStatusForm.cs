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
    public partial class myStatusForm : Form
    {
        Form1 _mainForm = new Form1();
        public myStatusForm(ref Form1 mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
        }

        public void Status_Click(object sender, EventArgs e)
        {

        }

        public void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainForm.Show();
            
        }

        private void myStatusForm_Load(object sender, EventArgs e)
        {

        }
    }
}
