namespace SmartHome_V3
{
    partial class FunctionView
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
            this.uxCheckList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // uxCheckList
            // 
            this.uxCheckList.FormattingEnabled = true;
            this.uxCheckList.Location = new System.Drawing.Point(12, 12);
            this.uxCheckList.Name = "uxCheckList";
            this.uxCheckList.Size = new System.Drawing.Size(452, 319);
            this.uxCheckList.TabIndex = 1;
            // 
            // FunctionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 350);
            this.Controls.Add(this.uxCheckList);
            this.Name = "FunctionView";
            this.Text = "FunctionView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox uxCheckList;
    }
}