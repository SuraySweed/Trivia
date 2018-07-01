namespace NewTriviaClient
{
    partial class JoinRoomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoinRoomForm));
            this.BackButton = new System.Windows.Forms.Button();
            this.NameOfUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RoomsList = new System.Windows.Forms.ListBox();
            this.UsersText = new System.Windows.Forms.Label();
            this.UsersInRoomList = new System.Windows.Forms.ListBox();
            this.JoinButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(620, 553);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(101, 38);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NameOfUser
            // 
            this.NameOfUser.AutoSize = true;
            this.NameOfUser.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameOfUser.Location = new System.Drawing.Point(12, 571);
            this.NameOfUser.Name = "NameOfUser";
            this.NameOfUser.Size = new System.Drawing.Size(87, 20);
            this.NameOfUser.TabIndex = 3;
            this.NameOfUser.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Miriam Fixed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Peru;
            this.label1.Location = new System.Drawing.Point(231, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 47);
            this.label1.TabIndex = 22;
            this.label1.Text = "Join Room";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(22, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Room in Server -->";
            // 
            // RoomsList
            // 
            this.RoomsList.BackColor = System.Drawing.Color.LightSteelBlue;
            this.RoomsList.Font = new System.Drawing.Font("Miriam Fixed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomsList.ForeColor = System.Drawing.Color.White;
            this.RoomsList.FormattingEnabled = true;
            this.RoomsList.ItemHeight = 27;
            this.RoomsList.Location = new System.Drawing.Point(26, 191);
            this.RoomsList.Name = "RoomsList";
            this.RoomsList.Size = new System.Drawing.Size(332, 274);
            this.RoomsList.TabIndex = 37;
            this.RoomsList.SelectedIndexChanged += new System.EventHandler(this.RoomsList_SelectedIndexChanged);
            // 
            // UsersText
            // 
            this.UsersText.AutoSize = true;
            this.UsersText.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersText.ForeColor = System.Drawing.Color.Black;
            this.UsersText.Location = new System.Drawing.Point(364, 266);
            this.UsersText.Name = "UsersText";
            this.UsersText.Size = new System.Drawing.Size(204, 20);
            this.UsersText.TabIndex = 38;
            this.UsersText.Text = "Users In Room: ";
            this.UsersText.Visible = false;
            // 
            // UsersInRoomList
            // 
            this.UsersInRoomList.BackColor = System.Drawing.Color.Peru;
            this.UsersInRoomList.Font = new System.Drawing.Font("Miriam Fixed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersInRoomList.ForeColor = System.Drawing.Color.Lavender;
            this.UsersInRoomList.FormattingEnabled = true;
            this.UsersInRoomList.ItemHeight = 27;
            this.UsersInRoomList.Location = new System.Drawing.Point(397, 299);
            this.UsersInRoomList.Name = "UsersInRoomList";
            this.UsersInRoomList.Size = new System.Drawing.Size(281, 166);
            this.UsersInRoomList.TabIndex = 39;
            this.UsersInRoomList.Visible = false;
            // 
            // JoinButton
            // 
            this.JoinButton.BackColor = System.Drawing.Color.SteelBlue;
            this.JoinButton.Font = new System.Drawing.Font("Miriam Fixed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinButton.ForeColor = System.Drawing.Color.White;
            this.JoinButton.Location = new System.Drawing.Point(397, 201);
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.Size = new System.Drawing.Size(192, 48);
            this.JoinButton.TabIndex = 40;
            this.JoinButton.Text = "Join";
            this.JoinButton.UseVisualStyleBackColor = false;
            // 
            // JoinRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 603);
            this.Controls.Add(this.JoinButton);
            this.Controls.Add(this.UsersInRoomList);
            this.Controls.Add(this.UsersText);
            this.Controls.Add(this.RoomsList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameOfUser);
            this.Controls.Add(this.BackButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JoinRoomForm";
            this.Text = "JoinRoomForm";
            this.Load += new System.EventHandler(this.JoinRoomForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        public System.Windows.Forms.Label NameOfUser;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox RoomsList;
        public System.Windows.Forms.Label UsersText;
        private System.Windows.Forms.ListBox UsersInRoomList;
        private System.Windows.Forms.Button JoinButton;
    }
}