namespace SmartHome_V3
{
    partial class Graph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.uxChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.uxChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // uxChart
            // 
            chartArea1.Name = "ChartArea1";
            this.uxChart.ChartAreas.Add(chartArea1);
            this.uxChart.Cursor = System.Windows.Forms.Cursors.Arrow;
            legend1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            legend1.Name = "Legend1";
            this.uxChart.Legends.Add(legend1);
            this.uxChart.Location = new System.Drawing.Point(21, 27);
            this.uxChart.Name = "uxChart";
            this.uxChart.Size = new System.Drawing.Size(928, 405);
            this.uxChart.TabIndex = 0;
            this.uxChart.Text = "chart1";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 454);
            this.Controls.Add(this.uxChart);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.Name = "Graph";
            this.Text = "Graph";
            this.SizeChanged += new System.EventHandler(this.ChartForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.uxChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart uxChart;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}