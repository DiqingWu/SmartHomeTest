namespace SmartHome_V3
{
    partial class DataAnalyze
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
            this.components = new System.ComponentModel.Container();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uxView3 = new System.Windows.Forms.ListBox();
            this.uxView2 = new System.Windows.Forms.ListBox();
            this.uxView1 = new System.Windows.Forms.ListBox();
            this.uxView = new System.Windows.Forms.ListBox();
            this.uxGraph = new System.Windows.Forms.Button();
            this.uxRealTime = new System.Windows.Forms.CheckBox();
            this.uxDateStart = new System.Windows.Forms.DateTimePicker();
            this.uxDateEnd = new System.Windows.Forms.DateTimePicker();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.uxRealTimeCount = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.uxDaySelected = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(390, 13);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(120, 20);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "Data (Json)";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(227, 13);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(120, 20);
            this.textBox3.TabIndex = 16;
            this.textBox3.Text = "Time Created";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(138, 13);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "Device IP";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "Home IP";
            // 
            // uxView3
            // 
            this.uxView3.FormattingEnabled = true;
            this.uxView3.Location = new System.Drawing.Point(390, 39);
            this.uxView3.Name = "uxView3";
            this.uxView3.Size = new System.Drawing.Size(335, 238);
            this.uxView3.TabIndex = 13;
            // 
            // uxView2
            // 
            this.uxView2.FormattingEnabled = true;
            this.uxView2.Location = new System.Drawing.Point(227, 39);
            this.uxView2.Name = "uxView2";
            this.uxView2.Size = new System.Drawing.Size(157, 238);
            this.uxView2.TabIndex = 12;
            // 
            // uxView1
            // 
            this.uxView1.FormattingEnabled = true;
            this.uxView1.Location = new System.Drawing.Point(138, 39);
            this.uxView1.Name = "uxView1";
            this.uxView1.Size = new System.Drawing.Size(83, 238);
            this.uxView1.TabIndex = 11;
            // 
            // uxView
            // 
            this.uxView.FormattingEnabled = true;
            this.uxView.Location = new System.Drawing.Point(12, 39);
            this.uxView.Name = "uxView";
            this.uxView.Size = new System.Drawing.Size(120, 238);
            this.uxView.TabIndex = 10;
            // 
            // uxGraph
            // 
            this.uxGraph.Location = new System.Drawing.Point(597, 293);
            this.uxGraph.Name = "uxGraph";
            this.uxGraph.Size = new System.Drawing.Size(128, 41);
            this.uxGraph.TabIndex = 18;
            this.uxGraph.Text = "Make Graph";
            this.uxGraph.UseVisualStyleBackColor = true;
            this.uxGraph.Click += new System.EventHandler(this.UxGraph_Click);
            // 
            // uxRealTime
            // 
            this.uxRealTime.AutoSize = true;
            this.uxRealTime.Location = new System.Drawing.Point(390, 283);
            this.uxRealTime.Name = "uxRealTime";
            this.uxRealTime.Size = new System.Drawing.Size(71, 17);
            this.uxRealTime.TabIndex = 19;
            this.uxRealTime.Text = "RealTime";
            this.uxRealTime.UseVisualStyleBackColor = true;
            // 
            // uxDateStart
            // 
            this.uxDateStart.Location = new System.Drawing.Point(9, 314);
            this.uxDateStart.Name = "uxDateStart";
            this.uxDateStart.Size = new System.Drawing.Size(200, 20);
            this.uxDateStart.TabIndex = 22;
            this.uxDateStart.Value = new System.DateTime(2019, 7, 26, 0, 0, 0, 0);
            // 
            // uxDateEnd
            // 
            this.uxDateEnd.Location = new System.Drawing.Point(241, 314);
            this.uxDateEnd.Name = "uxDateEnd";
            this.uxDateEnd.Size = new System.Drawing.Size(200, 20);
            this.uxDateEnd.TabIndex = 23;
            this.uxDateEnd.Value = new System.DateTime(2019, 7, 26, 0, 0, 0, 0);
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(215, 314);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(20, 20);
            this.textBox5.TabIndex = 24;
            this.textBox5.Text = "To";
            // 
            // uxRealTimeCount
            // 
            this.uxRealTimeCount.Location = new System.Drawing.Point(467, 281);
            this.uxRealTimeCount.Name = "uxRealTimeCount";
            this.uxRealTimeCount.Size = new System.Drawing.Size(31, 20);
            this.uxRealTimeCount.TabIndex = 25;
            this.uxRealTimeCount.Text = "10";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(504, 284);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(30, 20);
            this.textBox6.TabIndex = 27;
            this.textBox6.Text = "Min";
            // 
            // uxDaySelected
            // 
            this.uxDaySelected.AutoSize = true;
            this.uxDaySelected.Location = new System.Drawing.Point(12, 287);
            this.uxDaySelected.Name = "uxDaySelected";
            this.uxDaySelected.Size = new System.Drawing.Size(97, 17);
            this.uxDaySelected.TabIndex = 20;
            this.uxDaySelected.Text = "Graph By Days";
            this.uxDaySelected.UseVisualStyleBackColor = true;
            // 
            // DataAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 342);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.uxRealTimeCount);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.uxDateEnd);
            this.Controls.Add(this.uxDateStart);
            this.Controls.Add(this.uxDaySelected);
            this.Controls.Add(this.uxRealTime);
            this.Controls.Add(this.uxGraph);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.uxView3);
            this.Controls.Add(this.uxView2);
            this.Controls.Add(this.uxView1);
            this.Controls.Add(this.uxView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DataAnalyze";
            this.Text = "DataAnalyze";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox uxView3;
        private System.Windows.Forms.ListBox uxView2;
        private System.Windows.Forms.ListBox uxView1;
        private System.Windows.Forms.ListBox uxView;
        private System.Windows.Forms.Button uxGraph;
        private System.Windows.Forms.CheckBox uxRealTime;
        private System.Windows.Forms.DateTimePicker uxDateStart;
        private System.Windows.Forms.DateTimePicker uxDateEnd;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox uxRealTimeCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.CheckBox uxDaySelected;
    }
}