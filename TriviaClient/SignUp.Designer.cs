namespace NewTriviaClient
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.signUpLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.UserNameText = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.EmailText = new System.Windows.Forms.TextBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // signUpLabel
            // 
            this.signUpLabel.AutoSize = true;
            this.signUpLabel.BackColor = System.Drawing.Color.Transparent;
            this.signUpLabel.Font = new System.Drawing.Font("Miriam Fixed", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpLabel.ForeColor = System.Drawing.Color.Peru;
            this.signUpLabel.Location = new System.Drawing.Point(299, 45);
            this.signUpLabel.Name = "signUpLabel";
            this.signUpLabel.Size = new System.Drawing.Size(169, 36);
            this.signUpLabel.TabIndex = 21;
            this.signUpLabel.Text = "Sign Up";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(125, 139);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(101, 20);
            this.usernameLabel.TabIndex = 22;
            this.usernameLabel.Text = "User Name : ";
            // 
            // UserNameText
            // 
            this.UserNameText.Location = new System.Drawing.Point(233, 141);
            this.UserNameText.Name = "UserNameText";
            this.UserNameText.Size = new System.Drawing.Size(235, 20);
            this.UserNameText.TabIndex = 23;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(125, 196);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(90, 20);
            this.passwordLabel.TabIndex = 24;
            this.passwordLabel.Text = "Password : ";
            // 
            // PasswordText
            // 
            this.PasswordText.Location = new System.Drawing.Point(233, 198);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(235, 20);
            this.PasswordText.TabIndex = 25;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(125, 259);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(60, 20);
            this.emailLabel.TabIndex = 26;
            this.emailLabel.Text = "Email : ";
            // 
            // EmailText
            // 
            this.EmailText.Location = new System.Drawing.Point(233, 259);
            this.EmailText.Name = "EmailText";
            this.EmailText.Size = new System.Drawing.Size(235, 20);
            this.EmailText.TabIndex = 27;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.SteelBlue;
            this.BackButton.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(631, 375);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(101, 38);
            this.BackButton.TabIndex = 28;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.EmailText);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.UserNameText);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.signUpLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label signUpLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox UserNameText;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox EmailText;
        private System.Windows.Forms.Button BackButton;
    }
}