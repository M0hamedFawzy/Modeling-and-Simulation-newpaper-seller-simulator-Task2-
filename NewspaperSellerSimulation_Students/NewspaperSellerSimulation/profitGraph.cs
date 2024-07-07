using NewspaperSellerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NewspaperSellerSimulation
{
    public partial class profitGraph : Form
    {
        SimulationSystem system;
        public profitGraph()
        {
            InitializeComponent();
            system = SharedData.system;
            FillChart();
        }


        private void FillChart()
        {
            // Clear any existing data in the chart
            profitChart.Series.Clear();

            // Create a new series for the chart
            Series series = new Series("DailyNetProfit");
            //series.ChartType = SeriesChartType.Column; // You can choose a different chart type if needed
            series.ChartType = SeriesChartType.Column;
            // Add data points to the series
            for (int i = 0; i < system.NumOfRecords; i++)
            {
                // Assuming your system.SimulationTable has a property named DailyNetProfit
                decimal dailyNetProfit = system.SimulationTable[i].DailyNetProfit;

               
                series.Points.AddXY(i + 1, dailyNetProfit); // i + 1 to start from 1 instead of 0
            }

            // Add the series to the chart
            profitChart.Series.Add(series);

            // Optionally, you can customize the chart appearance
            profitChart.ChartAreas[0].AxisX.Title = "Day";
            profitChart.ChartAreas[0].AxisY.Title = "Daily Net Profit";
        }

        private void profitChart_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void profitGraph_Load(object sender, EventArgs e)
        {

        }
    }
}
