namespace SmartHome_V3
{
    partial class Login
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
            this.uxLoginPassword = new System.Windows.Forms.TextBox();
            this.uxLoginAccount = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.uxLogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxLoginPassword
            // 
            this.uxLoginPassword.Location = new System.Drawing.Point(141, 69);
            this.uxLoginPassword.Name = "uxLoginPassword";
            this.uxLoginPassword.Size = new System.Drawing.Size(100, 20);
            this.uxLoginPassword.TabIndex = 10;
            // 
            // uxLoginAccount
            // 
            this.uxLoginAccount.Location = new System.Drawing.Point(141, 22);
            this.uxLoginAccount.Name = "uxLoginAccount";
            this.uxLoginAccount.Size = new System.Drawing.Size(100, 20);
            this.uxLoginAccount.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(16, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Username";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(16, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 13);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "Password";
            // 
            // uxLogin
            // 
            this.uxLogin.Location = new System.Drawing.Point(166, 119);
            this.uxLogin.Name = "uxLogin";
            this.uxLogin.Size = new System.Drawing.Size(75, 23);
            this.uxLogin.TabIndex = 13;
            this.uxLogin.Text = "Login";
            this.uxLogin.UseVisualStyleBackColor = true;
            this.uxLogin.Click += new System.EventHandler(this.UxLogin_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Forgot Password";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 167);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uxLogin);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.uxLoginPassword);
            this.Controls.Add(this.uxLoginAccount);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxLoginPassword;
        private System.Windows.Forms.TextBox uxLoginAccount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button uxLogin;
        private System.Windows.Forms.Button button1;
    }
}