namespace NewTriviaClient
{
    partial class CreateRoomForm
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
            this.BackButton = new System.Windows.Forms.Button();
            this.NameOfUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RoomName = new System.Windows.Forms.Label();
            this.NumOPlayers = new System.Windows.Forms.Label();
            this.NumOQuestions = new System.Windows.Forms.Label();
            this.TimeForQuestion = new System.Windows.Forms.Label();
            this.Room_Name_text = new System.Windows.Forms.TextBox();
            this.Num_Of_Players = new System.Windows.Forms.TextBox();
            this.Num_Of_Questions = new System.Windows.Forms.TextBox();
            this.Time_For_Questions = new System.Windows.Forms.TextBox();
            this.CreateRoomButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(584, 429);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(101, 38);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NameOfUser
            // 
            this.NameOfUser.AutoSize = true;
            this.NameOfUser.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameOfUser.Location = new System.Drawing.Point(44, 447);
            this.NameOfUser.Name = "NameOfUser";
            this.NameOfUser.Size = new System.Drawing.Size(87, 20);
            this.NameOfUser.TabIndex = 2;
            this.NameOfUser.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Miriam Fixed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Peru;
            this.label1.Location = new System.Drawing.Point(214, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 47);
            this.label1.TabIndex = 21;
            this.label1.Text = "Create Room";
            // 
            // RoomName
            // 
            this.RoomName.AutoSize = true;
            this.RoomName.Font = new System.Drawing.Font("Miriam Fixed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomName.Location = new System.Drawing.Point(87, 154);
            this.RoomName.Name = "RoomName";
            this.RoomName.Size = new System.Drawing.Size(182, 27);
            this.RoomName.TabIndex = 22;
            this.RoomName.Text = "Room Name:";
            // 
            // NumOPlayers
            // 
            this.NumOPlayers.AutoSize = true;
            this.NumOPlayers.Font = new System.Drawing.Font("Miriam Fixed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOPlayers.Location = new System.Drawing.Point(87, 206);
            this.NumOPlayers.Name = "NumOPlayers";
            this.NumOPlayers.Size = new System.Drawing.Size(318, 27);
            this.NumOPlayers.TabIndex = 23;
            this.NumOPlayers.Text = "Number Of Players:";
            // 
            // NumOQuestions
            // 
            this.NumOQuestions.AutoSize = true;
            this.NumOQuestions.Font = new System.Drawing.Font("Miriam Fixed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOQuestions.Location = new System.Drawing.Point(87, 256);
            this.NumOQuestions.Name = "NumOQuestions";
            this.NumOQuestions.Size = new System.Drawing.Size(352, 27);
            this.NumOQuestions.TabIndex = 24;
            this.NumOQuestions.Text = "Number Of Questions:";
            // 
            // TimeForQuestion
            // 
            this.TimeForQuestion.AutoSize = true;
            this.TimeForQuestion.Font = new System.Drawing.Font("Miriam Fixed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeForQuestion.Location = new System.Drawing.Point(87, 308);
            this.TimeForQuestion.Name = "TimeForQuestion";
            this.TimeForQuestion.Size = new System.Drawing.Size(335, 27);
            this.TimeForQuestion.TabIndex = 25;
            this.TimeForQuestion.Text = "Time For Question: ";
            // 
            // Room_Name_text
            // 
            this.Room_Name_text.Location = new System.Drawing.Point(275, 161);
            this.Room_Name_text.Name = "Room_Name_text";
            this.Room_Name_text.Size = new System.Drawing.Size(235, 20);
            this.Room_Name_text.TabIndex = 26;
            // 
            // Num_Of_Players
            // 
            this.Num_Of_Players.Location = new System.Drawing.Point(411, 212);
            this.Num_Of_Players.Name = "Num_Of_Players";
            this.Num_Of_Players.Size = new System.Drawing.Size(99, 20);
            this.Num_Of_Players.TabIndex = 27;
            // 
            // Num_Of_Questions
            // 
            this.Num_Of_Questions.Location = new System.Drawing.Point(445, 263);
            this.Num_Of_Questions.Name = "Num_Of_Questions";
            this.Num_Of_Questions.Size = new System.Drawing.Size(65, 20);
            this.Num_Of_Questions.TabIndex = 28;
            // 
            // Time_For_Questions
            // 
            this.Time_For_Questions.Location = new System.Drawing.Point(411, 314);
            this.Time_For_Questions.Name = "Time_For_Questions";
            this.Time_For_Questions.Size = new System.Drawing.Size(99, 20);
            this.Time_For_Questions.TabIndex = 29;
            // 
            // CreateRoomButton
            // 
            this.CreateRoomButton.BackColor = System.Drawing.Color.SteelBlue;
            this.CreateRoomButton.Font = new System.Drawing.Font("Miriam Fixed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateRoomButton.ForeColor = System.Drawing.Color.White;
            this.CreateRoomButton.Location = new System.Drawing.Point(554, 206);
            this.CreateRoomButton.Name = "CreateRoomButton";
            this.CreateRoomButton.Size = new System.Drawing.Size(131, 92);
            this.CreateRoomButton.TabIndex = 30;
            this.CreateRoomButton.Text = "CREATE";
            this.CreateRoomButton.UseVisualStyleBackColor = false;
            this.CreateRoomButton.Click += new System.EventHandler(this.CreateRoomButton_Click);
            // 
            // CreateRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 491);
            this.Controls.Add(this.CreateRoomButton);
            this.Controls.Add(this.Time_For_Questions);
            this.Controls.Add(this.Num_Of_Questions);
            this.Controls.Add(this.Num_Of_Players);
            this.Controls.Add(this.Room_Name_text);
            this.Controls.Add(this.TimeForQuestion);
            this.Controls.Add(this.NumOQuestions);
            this.Controls.Add(this.NumOPlayers);
            this.Controls.Add(this.RoomName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameOfUser);
            this.Controls.Add(this.BackButton);
            this.Name = "CreateRoomForm";
            this.Text = "CreateRoomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        public System.Windows.Forms.Label NameOfUser;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RoomName;
        private System.Windows.Forms.Label NumOPlayers;
        private System.Windows.Forms.Label NumOQuestions;
        private System.Windows.Forms.Label TimeForQuestion;
        private System.Windows.Forms.TextBox Room_Name_text;
        private System.Windows.Forms.TextBox Num_Of_Players;
        private System.Windows.Forms.TextBox Num_Of_Questions;
        private System.Windows.Forms.TextBox Time_For_Questions;
        private System.Windows.Forms.Button CreateRoomButton;
    }
}