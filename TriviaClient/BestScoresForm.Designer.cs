namespace NewTriviaClient
{
    partial class BestScoresForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BestScoresForm));
            this.BestScore = new System.Windows.Forms.Label();
            this.BestScoreText = new System.Windows.Forms.Label();
            this.NameOfUser = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BestScore
            // 
            this.BestScore.AutoSize = true;
            this.BestScore.BackColor = System.Drawing.Color.Transparent;
            this.BestScore.Font = new System.Drawing.Font("Miriam Fixed", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BestScore.ForeColor = System.Drawing.Color.Peru;
            this.BestScore.Location = new System.Drawing.Point(207, 36);
            this.BestScore.Name = "BestScore";
            this.BestScore.Size = new System.Drawing.Size(235, 36);
            this.BestScore.TabIndex = 21;
            this.BestScore.Text = "Best Score";
            // 
            // BestScoreText
            // 
            this.BestScoreText.AutoSize = true;
            this.BestScoreText.Font = new System.Drawing.Font("Miriam Fixed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BestScoreText.Location = new System.Drawing.Point(115, 121);
            this.BestScoreText.Name = "BestScoreText";
            this.BestScoreText.Size = new System.Drawing.Size(0, 32);
            this.BestScoreText.TabIndex = 22;
            // 
            // NameOfUser
            // 
            this.NameOfUser.AutoSize = true;
            this.NameOfUser.Font = new System.Drawing.Font("Miriam Fixed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameOfUser.Location = new System.Drawing.Point(28, 345);
            this.NameOfUser.Name = "NameOfUser";
            this.NameOfUser.Size = new System.Drawing.Size(87, 20);
            this.NameOfUser.TabIndex = 23;
            this.NameOfUser.Text = "label1";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(547, 327);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(101, 38);
            this.BackButton.TabIndex = 24;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // BestScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 394);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.NameOfUser);
            this.Controls.Add(this.BestScoreText);
            this.Controls.Add(this.BestScore);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BestScoresForm";
            this.Text = "BestScoresForm";
            this.Load += new System.EventHandler(this.BestScoresForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label BestScore;
        public System.Windows.Forms.Label BestScoreText;
        public System.Windows.Forms.Label NameOfUser;
        private System.Windows.Forms.Button BackButton;
    }
}