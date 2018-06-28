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
    public partial class BestScoresForm : Form
    {
        Form1 _mainForm = new Form1();
        public BestScoresForm(ref Form1 mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
        }

        private void BestScoresForm_Load(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _mainForm.Show();
        }
    }
}
