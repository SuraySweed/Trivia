namespace NewTriviaClient
{
    partial class QuestionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionForm));
            this.ExitButton = new System.Windows.Forms.Button();
            this.NameOfUser = new System.Windows.Forms.Label();
            this.RoomName = new System.Windows.Forms.Label();
            this.NumOfQuestion = new System.Windows.Forms.Label();
            this.Question = new System.Windows.Forms.Label();
            this.Ans1Button = new System.Windows.Forms.Button();
            this.Ans2Button = new System.Windows.Forms.Button();
            this.Ans3Button = new System.Windows.Forms.Button();
            this.Ans4Button = new System.Windows.Forms.Button();
            this.TimeLeft = new System.Windows.Forms.Label();
            this.ScoreText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Peru;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitButton.Font = new System.Drawing.Font("Miriam Fixed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(602, 20);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 32);
            this.ExitButton.TabIndex = 14;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // NameOfUser
            // 
            this.NameOfUser.AutoSize = true;
            this.NameOfUser.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameOfUser.Location = new System.Drawing.Point(23, 20);
            this.NameOfUser.Name = "NameOfUser";
            this.NameOfUser.Size = new System.Drawing.Size(87, 20);
            this.NameOfUser.TabIndex = 15;
            this.NameOfUser.Text = "label1";
            // 
            // RoomName
            // 
            this.RoomName.AutoSize = true;
            this.RoomName.BackColor = System.Drawing.Color.Transparent;
            this.RoomName.Font = new System.Drawing.Font("Miriam Fixed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomName.ForeColor = System.Drawing.Color.Peru;
            this.RoomName.Location = new System.Drawing.Point(205, 20);
            this.RoomName.Name = "RoomName";
            this.RoomName.Size = new System.Drawing.Size(281, 47);
            this.RoomName.TabIndex = 22;
            this.RoomName.Text = "Room Name";
            // 
            // NumOfQuestion
            // 
            this.NumOfQuestion.AutoSize = true;
            this.NumOfQuestion.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfQuestion.Location = new System.Drawing.Point(269, 107);
            this.NumOfQuestion.Name = "NumOfQuestion";
            this.NumOfQuestion.Size = new System.Drawing.Size(108, 16);
            this.NumOfQuestion.TabIndex = 23;
            this.NumOfQuestion.Text = "Question #";
            // 
            // Question
            // 
            this.Question.AutoSize = true;
            this.Question.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Question.Location = new System.Drawing.Point(122, 154);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(93, 20);
            this.Question.TabIndex = 24;
            this.Question.Text = "label2";
            // 
            // Ans1Button
            // 
            this.Ans1Button.BackColor = System.Drawing.Color.SteelBlue;
            this.Ans1Button.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ans1Button.ForeColor = System.Drawing.Color.White;
            this.Ans1Button.Location = new System.Drawing.Point(77, 213);
            this.Ans1Button.Name = "Ans1Button";
            this.Ans1Button.Size = new System.Drawing.Size(544, 54);
            this.Ans1Button.TabIndex = 25;
            this.Ans1Button.Text = "ans1";
            this.Ans1Button.UseVisualStyleBackColor = false;
            this.Ans1Button.Click += new System.EventHandler(this.Ans1Button_Click);
            // 
            // Ans2Button
            // 
            this.Ans2Button.BackColor = System.Drawing.Color.SteelBlue;
            this.Ans2Button.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ans2Button.ForeColor = System.Drawing.Color.White;
            this.Ans2Button.Location = new System.Drawing.Point(77, 283);
            this.Ans2Button.Name = "Ans2Button";
            this.Ans2Button.Size = new System.Drawing.Size(544, 54);
            this.Ans2Button.TabIndex = 26;
            this.Ans2Button.Text = "ans2";
            this.Ans2Button.UseVisualStyleBackColor = false;
            this.Ans2Button.Click += new System.EventHandler(this.Ans2Button_Click);
            // 
            // Ans3Button
            // 
            this.Ans3Button.BackColor = System.Drawing.Color.SteelBlue;
            this.Ans3Button.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ans3Button.ForeColor = System.Drawing.Color.White;
            this.Ans3Button.Location = new System.Drawing.Point(77, 355);
            this.Ans3Button.Name = "Ans3Button";
            this.Ans3Button.Size = new System.Drawing.Size(544, 54);
            this.Ans3Button.TabIndex = 27;
            this.Ans3Button.Text = "ans3";
            this.Ans3Button.UseVisualStyleBackColor = false;
            this.Ans3Button.Click += new System.EventHandler(this.Ans3Button_Click);
            // 
            // Ans4Button
            // 
            this.Ans4Button.BackColor = System.Drawing.Color.SteelBlue;
            this.Ans4Button.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ans4Button.ForeColor = System.Drawing.Color.White;
            this.Ans4Button.Location = new System.Drawing.Point(77, 429);
            this.Ans4Button.Name = "Ans4Button";
            this.Ans4Button.Size = new System.Drawing.Size(544, 54);
            this.Ans4Button.TabIndex = 28;
            this.Ans4Button.Text = "ans4";
            this.Ans4Button.UseVisualStyleBackColor = false;
            this.Ans4Button.Click += new System.EventHandler(this.Ans4Button_Click);
            // 
            // TimeLeft
            // 
            this.TimeLeft.AutoSize = true;
            this.TimeLeft.Font = new System.Drawing.Font("Miriam Fixed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLeft.Location = new System.Drawing.Point(331, 512);
            this.TimeLeft.Name = "TimeLeft";
            this.TimeLeft.Size = new System.Drawing.Size(46, 27);
            this.TimeLeft.TabIndex = 29;
            this.TimeLeft.Text = "20";
            // 
            // ScoreText
            // 
            this.ScoreText.AutoSize = true;
            this.ScoreText.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreText.Location = new System.Drawing.Point(291, 555);
            this.ScoreText.Name = "ScoreText";
            this.ScoreText.Size = new System.Drawing.Size(58, 16);
            this.ScoreText.TabIndex = 30;
            this.ScoreText.Text = "Score";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(698, 590);
            this.Controls.Add(this.ScoreText);
            this.Controls.Add(this.TimeLeft);
            this.Controls.Add(this.Ans4Button);
            this.Controls.Add(this.Ans3Button);
            this.Controls.Add(this.Ans2Button);
            this.Controls.Add(this.Ans1Button);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.NumOfQuestion);
            this.Controls.Add(this.RoomName);
            this.Controls.Add(this.NameOfUser);
            this.Controls.Add(this.ExitButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuestionForm";
            this.Text = "QuestionForm";
            this.Load += new System.EventHandler(this.QuestionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        public System.Windows.Forms.Label NameOfUser;
        public System.Windows.Forms.Label RoomName;
        private System.Windows.Forms.Label NumOfQuestion;
        private System.Windows.Forms.Label Question;
        private System.Windows.Forms.Button Ans1Button;
        private System.Windows.Forms.Button Ans2Button;
        private System.Windows.Forms.Button Ans3Button;
        private System.Windows.Forms.Button Ans4Button;
        private System.Windows.Forms.Label TimeLeft;
        private System.Windows.Forms.Label ScoreText;
        private System.Windows.Forms.Timer timer1;
    }
}