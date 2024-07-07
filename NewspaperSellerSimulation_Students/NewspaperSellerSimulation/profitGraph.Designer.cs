namespace NewspaperSellerSimulation
{
    partial class profitGraph
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.profitChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.profitChart)).BeginInit();
            this.SuspendLayout();
            // 
            // profitChart
            // 
            this.profitChart.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.profitChart.BorderSkin.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DashedHorizontal;
            chartArea1.Name = "ChartArea1";
            this.profitChart.ChartAreas.Add(chartArea1);
            this.profitChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.profitChart.Legends.Add(legend1);
            this.profitChart.Location = new System.Drawing.Point(0, 0);
            this.profitChart.Name = "profitChart";
            this.profitChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.profitChart.Series.Add(series1);
            this.profitChart.Size = new System.Drawing.Size(800, 450);
            this.profitChart.TabIndex = 0;
            this.profitChart.Text = "chart1";
            this.profitChart.Click += new System.EventHandler(this.profitChart_Click);
            // 
            // profitGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.profitChart);
            this.Name = "profitGraph";
            this.Text = "profitGraph";
            this.Load += new System.EventHandler(this.profitGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.profitChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart profitChart;
    }
}