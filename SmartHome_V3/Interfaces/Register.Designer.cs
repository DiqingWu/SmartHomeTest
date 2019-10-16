namespace SmartHome_V3
{
    partial class Register
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
            this.uxRegEmail = new System.Windows.Forms.TextBox();
            this.uxRegPassword = new System.Windows.Forms.TextBox();
            this.uxRegAccount = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.uxButton = new System.Windows.Forms.Button();
            this.uxVerify = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uxRegEmail
            // 
            this.uxRegEmail.Location = new System.Drawing.Point(120, 66);
            this.uxRegEmail.Name = "uxRegEmail";
            this.uxRegEmail.Size = new System.Drawing.Size(118, 20);
            this.uxRegEmail.TabIndex = 9;
            // 
            // uxRegPassword
            // 
            this.uxRegPassword.Location = new System.Drawing.Point(120, 42);
            this.uxRegPassword.Name = "uxRegPassword";
            this.uxRegPassword.PasswordChar = '*';
            this.uxRegPassword.Size = new System.Drawing.Size(118, 20);
            this.uxRegPassword.TabIndex = 8;
            // 
            // uxRegAccount
            // 
            this.uxRegAccount.Location = new System.Drawing.Point(120, 16);
            this.uxRegAccount.Name = "uxRegAccount";
            this.uxRegAccount.Size = new System.Drawing.Size(118, 20);
            this.uxRegAccount.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(14, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 13);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "Password";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(14, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Username";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(14, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 13);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "Email";
            // 
            // uxButton
            // 
            this.uxButton.Location = new System.Drawing.Point(163, 139);
            this.uxButton.Name = "uxButton";
            this.uxButton.Size = new System.Drawing.Size(75, 23);
            this.uxButton.TabIndex = 16;
            this.uxButton.Text = "Enter";
            this.uxButton.UseVisualStyleBackColor = true;
            this.uxButton.Click += new System.EventHandler(this.UxButton_Click);
            // 
            // uxVerify
            // 
            this.uxVerify.Location = new System.Drawing.Point(120, 104);
            this.uxVerify.Name = "uxVerify";
            this.uxVerify.Size = new System.Drawing.Size(118, 20);
            this.uxVerify.TabIndex = 17;
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(14, 111);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 13);
            this.textBox5.TabIndex = 18;
            this.textBox5.Text = "Verify Code:";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 184);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.uxVerify);
            this.Controls.Add(this.uxButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.uxRegEmail);
            this.Controls.Add(this.uxRegPassword);
            this.Controls.Add(this.uxRegAccount);
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxRegEmail;
        private System.Windows.Forms.TextBox uxRegPassword;
        private System.Windows.Forms.TextBox uxRegAccount;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button uxButton;
        private System.Windows.Forms.TextBox uxVerify;
        private System.Windows.Forms.TextBox textBox5;
    }
}