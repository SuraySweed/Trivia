namespace NewTriviaClient
{
    partial class NewlyCreatedRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewlyCreatedRoom));
            this.NameOfUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NamesList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // NameOfUser
            // 
            this.NameOfUser.AutoSize = true;
            this.NameOfUser.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameOfUser.Location = new System.Drawing.Point(23, 532);
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
            this.label1.Location = new System.Drawing.Point(244, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 47);
            this.label1.TabIndex = 22;
            this.label1.Text = "Room Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Miriam Fixed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Peru;
            this.label2.Location = new System.Drawing.Point(198, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(385, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "You are connected to room";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.SteelBlue;
            this.StartButton.Font = new System.Drawing.Font("Miriam Fixed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.ForeColor = System.Drawing.Color.White;
            this.StartButton.Location = new System.Drawing.Point(138, 428);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(177, 66);
            this.StartButton.TabIndex = 31;
            this.StartButton.Text = "START GAME";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Font = new System.Drawing.Font("Miriam Fixed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(445, 428);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 66);
            this.button1.TabIndex = 32;
            this.button1.Text = "CLOSE ROOM";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(58, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Current participants are:";
            // 
            // NamesList
            // 
            this.NamesList.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamesList.FormattingEnabled = true;
            this.NamesList.ItemHeight = 16;
            this.NamesList.Location = new System.Drawing.Point(62, 205);
            this.NamesList.Name = "NamesList";
            this.NamesList.Size = new System.Drawing.Size(527, 180);
            this.NamesList.TabIndex = 36;
            this.NamesList.SelectedIndexChanged += new System.EventHandler(this.NamesList_SelectedIndexChanged_1);
            // 
            // NewlyCreatedRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(761, 571);
            this.Controls.Add(this.NamesList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameOfUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewlyCreatedRoom";
            this.Text = "NewlyCreatedRoom";
            this.Load += new System.EventHandler(this.NewlyCreatedRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label NameOfUser;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox NamesList;
    }
}