namespace SmartHome_V3
{
    partial class SmartHomeServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartHomeServer));
            this.uxFunctionC = new System.Windows.Forms.Button();
            this.uxWSOn = new System.Windows.Forms.RadioButton();
            this.uxMqttOn = new System.Windows.Forms.RadioButton();
            this.uxWsStatus = new System.Windows.Forms.PictureBox();
            this.uxMqttStatus = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uxWSOff = new System.Windows.Forms.RadioButton();
            this.uxMqttOff = new System.Windows.Forms.RadioButton();
            this.uxDatabase = new System.Windows.Forms.Button();
            this.uxServerlog = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uxWsStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMqttStatus)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxFunctionC
            // 
            this.uxFunctionC.Location = new System.Drawing.Point(12, 214);
            this.uxFunctionC.Name = "uxFunctionC";
            this.uxFunctionC.Size = new System.Drawing.Size(238, 31);
            this.uxFunctionC.TabIndex = 24;
            this.uxFunctionC.Text = "Functions";
            this.uxFunctionC.UseVisualStyleBackColor = true;
            this.uxFunctionC.Click += new System.EventHandler(this.UxFunctionC_Click_1);
            // 
            // uxWSOn
            // 
            this.uxWSOn.AutoCheck = false;
            this.uxWSOn.AutoSize = true;
            this.uxWSOn.Location = new System.Drawing.Point(222, 68);
            this.uxWSOn.Name = "uxWSOn";
            this.uxWSOn.Size = new System.Drawing.Size(39, 17);
            this.uxWSOn.TabIndex = 23;
            this.uxWSOn.Text = "On";
            this.uxWSOn.UseVisualStyleBackColor = true;
            this.uxWSOn.CheckedChanged += new System.EventHandler(this.UxWSOn_CheckedChanged_1);
            // 
            // uxMqttOn
            // 
            this.uxMqttOn.AutoCheck = false;
            this.uxMqttOn.AutoSize = true;
            this.uxMqttOn.Location = new System.Drawing.Point(222, 43);
            this.uxMqttOn.Name = "uxMqttOn";
            this.uxMqttOn.Size = new System.Drawing.Size(39, 17);
            this.uxMqttOn.TabIndex = 22;
            this.uxMqttOn.Text = "On";
            this.uxMqttOn.UseVisualStyleBackColor = true;
            this.uxMqttOn.CheckedChanged += new System.EventHandler(this.UxMqttOn_CheckedChanged_1);
            // 
            // uxWsStatus
            // 
            this.uxWsStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uxWsStatus.BackgroundImage")));
            this.uxWsStatus.ErrorImage = global::SmartHome_V3.Properties.Resources.red;
            this.uxWsStatus.InitialImage = global::SmartHome_V3.Properties.Resources.red;
            this.uxWsStatus.Location = new System.Drawing.Point(12, 65);
            this.uxWsStatus.Name = "uxWsStatus";
            this.uxWsStatus.Size = new System.Drawing.Size(21, 20);
            this.uxWsStatus.TabIndex = 21;
            this.uxWsStatus.TabStop = false;
            // 
            // uxMqttStatus
            // 
            this.uxMqttStatus.ErrorImage = global::SmartHome_V3.Properties.Resources.yellow;
            this.uxMqttStatus.InitialImage = global::SmartHome_V3.Properties.Resources.red;
            this.uxMqttStatus.Location = new System.Drawing.Point(12, 39);
            this.uxMqttStatus.Name = "uxMqttStatus";
            this.uxMqttStatus.Size = new System.Drawing.Size(21, 20);
            this.uxMqttStatus.TabIndex = 20;
            this.uxMqttStatus.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(55, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(123, 19);
            this.textBox2.TabIndex = 19;
            this.textBox2.Text = "WebSocket Server:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(55, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 19);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "MQTT Server:";
            // 
            // uxWSOff
            // 
            this.uxWSOff.AutoCheck = false;
            this.uxWSOff.AutoSize = true;
            this.uxWSOff.Checked = true;
            this.uxWSOff.Location = new System.Drawing.Point(184, 68);
            this.uxWSOff.Name = "uxWSOff";
            this.uxWSOff.Size = new System.Drawing.Size(39, 17);
            this.uxWSOff.TabIndex = 17;
            this.uxWSOff.TabStop = true;
            this.uxWSOff.Text = "Off";
            this.uxWSOff.UseVisualStyleBackColor = true;
            this.uxWSOff.CheckedChanged += new System.EventHandler(this.UxWSOff_CheckedChanged_1);
            // 
            // uxMqttOff
            // 
            this.uxMqttOff.AutoCheck = false;
            this.uxMqttOff.AutoSize = true;
            this.uxMqttOff.Checked = true;
            this.uxMqttOff.Location = new System.Drawing.Point(184, 43);
            this.uxMqttOff.Name = "uxMqttOff";
            this.uxMqttOff.Size = new System.Drawing.Size(39, 17);
            this.uxMqttOff.TabIndex = 16;
            this.uxMqttOff.Text = "Off";
            this.uxMqttOff.UseVisualStyleBackColor = true;
            this.uxMqttOff.CheckedChanged += new System.EventHandler(this.UxMqttOff_CheckedChanged);
            // 
            // uxDatabase
            // 
            this.uxDatabase.Location = new System.Drawing.Point(12, 166);
            this.uxDatabase.Name = "uxDatabase";
            this.uxDatabase.Size = new System.Drawing.Size(238, 31);
            this.uxDatabase.TabIndex = 14;
            this.uxDatabase.Text = "Data Analyze";
            this.uxDatabase.UseVisualStyleBackColor = true;
            this.uxDatabase.Click += new System.EventHandler(this.UxDatabase_Click_1);
            // 
            // uxServerlog
            // 
            this.uxServerlog.Location = new System.Drawing.Point(12, 118);
            this.uxServerlog.Name = "uxServerlog";
            this.uxServerlog.Size = new System.Drawing.Size(238, 31);
            this.uxServerlog.TabIndex = 13;
            this.uxServerlog.Text = "Server Log";
            this.uxServerlog.UseVisualStyleBackColor = true;
            this.uxServerlog.Click += new System.EventHandler(this.UxServerlog_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(267, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // AccountButton
            // 
            this.AccountButton.Location = new System.Drawing.Point(12, 263);
            this.AccountButton.Name = "AccountButton";
            this.AccountButton.Size = new System.Drawing.Size(238, 31);
            this.AccountButton.TabIndex = 25;
            this.AccountButton.Text = "Account Manage";
            this.AccountButton.UseVisualStyleBackColor = true;
            this.AccountButton.Click += new System.EventHandler(this.AccountButton_Click);
            // 
            // SmartHomeServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 313);
            this.Controls.Add(this.AccountButton);
            this.Controls.Add(this.uxFunctionC);
            this.Controls.Add(this.uxWSOn);
            this.Controls.Add(this.uxMqttOn);
            this.Controls.Add(this.uxWsStatus);
            this.Controls.Add(this.uxMqttStatus);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.uxWSOff);
            this.Controls.Add(this.uxMqttOff);
            this.Controls.Add(this.uxDatabase);
            this.Controls.Add(this.uxServerlog);
            this.Controls.Add(this.menuStrip1);
            this.Name = "SmartHomeServer";
            this.Text = "Smart Home Server";
            ((System.ComponentModel.ISupportInitialize)(this.uxWsStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxMqttStatus)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxFunctionC;
        private System.Windows.Forms.RadioButton uxWSOn;
        private System.Windows.Forms.RadioButton uxMqttOn;
        private System.Windows.Forms.PictureBox uxWsStatus;
        private System.Windows.Forms.PictureBox uxMqttStatus;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton uxWSOff;
        private System.Windows.Forms.RadioButton uxMqttOff;
        private System.Windows.Forms.Button uxDatabase;
        private System.Windows.Forms.Button uxServerlog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.Button AccountButton;
    }
}

