﻿using System;
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
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 trivia = new Form1();
            trivia.Show();
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
