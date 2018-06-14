using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriviaClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        int NTop = 4;
        private void timer1_Tick(object sender, EventArgs e)
        {
            BackPic1.Top--;
            if(BackPic1.Bottom <= 0)
            {
                BackPic1.Top = this.ClientRectangle.Bottom;
            }

            BackPic2.Top--;
            if (BackPic2.Bottom <= 0)
            {
                BackPic2.Top = this.ClientRectangle.Bottom;
            }

            BackPic3.Top--;
            if (BackPic3.Bottom <= 0)
            {
                BackPic3.Top = this.ClientRectangle.Bottom;
            }

            BackPic4.Top--;
            if (BackPic4.Bottom <= 0)
            {
                BackPic4.Top = this.ClientRectangle.Bottom;
            }

            BackPic5.Top--;
            if (BackPic5.Bottom <= 0)
            {
                BackPic5.Top = this.ClientRectangle.Bottom;
            }


            BackPic6.Top--;
            if (BackPic6.Bottom <= 0)
            {
                BackPic6.Top = this.ClientRectangle.Bottom;
            }

            BackPic7.Top--;
            if (BackPic7.Bottom <= 0)
            {
                BackPic7.Top = this.ClientRectangle.Bottom;
            }

            BackPic8.Top--;
            if (BackPic8.Bottom <= 0)
            {
                BackPic8.Top = this.ClientRectangle.Bottom;
            }
        }
    }
}
