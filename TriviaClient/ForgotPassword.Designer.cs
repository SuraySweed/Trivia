namespace NewTriviaClient
{
    partial class ForgotPassword
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
            this.forgotPasswordLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UserNameText = new System.Windows.Forms.TextBox();
            this.Rest_Button = new System.Windows.Forms.Button();
            this.AnsFromDataBase = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // forgotPasswordLabel
            // 
            this.forgotPasswordLabel.AutoSize = true;
            this.forgotPasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.forgotPasswordLabel.Font = new System.Drawing.Font("Miriam Fixed", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotPasswordLabel.ForeColor = System.Drawing.Color.Peru;
            this.forgotPasswordLabel.Location = new System.Drawing.Point(78, 30);
            this.forgotPasswordLabel.Name = "forgotPasswordLabel";
            this.forgotPasswordLabel.Size = new System.Drawing.Size(300, 32);
            this.forgotPasswordLabel.TabIndex = 22;
            this.forgotPasswordLabel.Text = "Forgot Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "USERNAME : ";
            // 
            // UserNameText
            // 
            this.UserNameText.Location = new System.Drawing.Point(154, 104);
            this.UserNameText.Name = "UserNameText";
            this.UserNameText.Size = new System.Drawing.Size(141, 20);
            this.UserNameText.TabIndex = 24;
            this.UserNameText.TextChanged += new System.EventHandler(this.UserNameText_TextChanged);
            // 
            // Rest_Button
            // 
            this.Rest_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rest_Button.Location = new System.Drawing.Point(154, 145);
            this.Rest_Button.Name = "Rest_Button";
            this.Rest_Button.Size = new System.Drawing.Size(124, 28);
            this.Rest_Button.TabIndex = 25;
            this.Rest_Button.Text = "Rest Password";
            this.Rest_Button.UseVisualStyleBackColor = true;
            this.Rest_Button.Click += new System.EventHandler(this.Rest_Button_Click);
            // 
            // AnsFromDataBase
            // 
            this.AnsFromDataBase.AutoSize = true;
            this.AnsFromDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnsFromDataBase.Location = new System.Drawing.Point(81, 202);
            this.AnsFromDataBase.Name = "AnsFromDataBase";
            this.AnsFromDataBase.Size = new System.Drawing.Size(0, 20);
            this.AnsFromDataBase.TabIndex = 26;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(343, 288);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(88, 29);
            this.BackButton.TabIndex = 27;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 343);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.AnsFromDataBase);
            this.Controls.Add(this.Rest_Button);
            this.Controls.Add(this.UserNameText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.forgotPasswordLabel);
            this.Name = "ForgotPassword";
            this.Text = "ForgotPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label forgotPasswordLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserNameText;
        private System.Windows.Forms.Button Rest_Button;
        private System.Windows.Forms.Label AnsFromDataBase;
        private System.Windows.Forms.Button BackButton;
    }
}