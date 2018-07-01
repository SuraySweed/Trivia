namespace NewTriviaClient
{
    partial class WaitingForGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingForGame));
            this.NamesList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LeaveRoomButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameOfUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NamesList
            // 
            this.NamesList.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamesList.FormattingEnabled = true;
            this.NamesList.ItemHeight = 16;
            this.NamesList.Location = new System.Drawing.Point(63, 246);
            this.NamesList.Name = "NamesList";
            this.NamesList.Size = new System.Drawing.Size(527, 180);
            this.NamesList.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(59, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Current participants are:";
            // 
            // LeaveRoomButton
            // 
            this.LeaveRoomButton.BackColor = System.Drawing.Color.SteelBlue;
            this.LeaveRoomButton.Font = new System.Drawing.Font("Miriam Fixed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeaveRoomButton.ForeColor = System.Drawing.Color.White;
            this.LeaveRoomButton.Location = new System.Drawing.Point(261, 454);
            this.LeaveRoomButton.Name = "LeaveRoomButton";
            this.LeaveRoomButton.Size = new System.Drawing.Size(173, 66);
            this.LeaveRoomButton.TabIndex = 40;
            this.LeaveRoomButton.Text = "LEAVE ROOM";
            this.LeaveRoomButton.UseVisualStyleBackColor = false;
            this.LeaveRoomButton.Click += new System.EventHandler(this.LeaveRoomButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Miriam Fixed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Peru;
            this.label1.Location = new System.Drawing.Point(208, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 47);
            this.label1.TabIndex = 38;
            this.label1.Text = "Room Name";
            // 
            // NameOfUser
            // 
            this.NameOfUser.AutoSize = true;
            this.NameOfUser.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameOfUser.Location = new System.Drawing.Point(24, 573);
            this.NameOfUser.Name = "NameOfUser";
            this.NameOfUser.Size = new System.Drawing.Size(87, 20);
            this.NameOfUser.TabIndex = 37;
            this.NameOfUser.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Miriam Fixed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Peru;
            this.label2.Location = new System.Drawing.Point(154, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(385, 24);
            this.label2.TabIndex = 43;
            this.label2.Text = "You are connected to room";
            // 
            // WaitingForGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(709, 614);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NamesList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LeaveRoomButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameOfUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WaitingForGame";
            this.Text = "WaitingForGame";
            this.Load += new System.EventHandler(this.WaitingForGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox NamesList;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LeaveRoomButton;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label NameOfUser;
        public System.Windows.Forms.Label label2;
    }
}