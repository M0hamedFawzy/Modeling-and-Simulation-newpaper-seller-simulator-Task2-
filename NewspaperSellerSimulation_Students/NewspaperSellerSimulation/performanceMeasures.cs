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

namespace NewspaperSellerSimulation
{
    public partial class performanceMeasures : Form
    {
        SimulationSystem system;
        public performanceMeasures()
        {
            InitializeComponent();
        }

        private void performanceMeasures_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            system = SharedData.system;
            label8.Text  = $"{system.PerformanceMeasures.TotalSalesProfit} $";
            label14.Text = $"{system.PerformanceMeasures.TotalCost} $";
            label13.Text = $"{system.PerformanceMeasures.TotalLostProfit}  $";
            label12.Text = $"{system.PerformanceMeasures.TotalScrapProfit}  $";
            label11.Text  = $"{system.PerformanceMeasures.TotalNetProfit}  $";
            label10.Text  = $"{system.PerformanceMeasures.DaysWithMoreDemand}";
            label9.Text  = $"{system.PerformanceMeasures.DaysWithUnsoldPapers}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text  = "0 $";
            label14.Text = "0 $";
            label13.Text = "0 $";
            label12.Text = "0 $";
            label11.Text  = "0 $";
            label10.Text  = "0";
            label9.Text  = "0";
        }
    }
}
