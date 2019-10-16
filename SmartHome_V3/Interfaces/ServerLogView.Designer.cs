namespace SmartHome_V3
{
    partial class ServerLogView
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
            this.uxLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uxLog
            // 
            this.uxLog.Location = new System.Drawing.Point(12, 34);
            this.uxLog.Multiline = true;
            this.uxLog.Name = "uxLog";
            this.uxLog.ReadOnly = true;
            this.uxLog.Size = new System.Drawing.Size(759, 375);
            this.uxLog.TabIndex = 0;
            // 
            // ServerLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 427);
            this.Controls.Add(this.uxLog);
            this.Name = "ServerLogView";
            this.Text = "ServerLogView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxLog;
    }
}