using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueModels;
using NewspaperSellerModels;
using NewspaperSellerTesting;

namespace NewspaperSellerSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            FileReader fileReader = new FileReader(@"D:\7th Semester\Modeling and Simulation\Task 2\NewspaperSellerSimulation_Students\NewspaperSellerSimulation\TestCases\TestCase3.txt");
            SimulationSystem system = fileReader.LoadData();
            system.fillTable();
            system.CalculatePerformanceMeasures();


            
            //string result = TestingManager.Test(system, Constants.FileNames.TestCase3);
            //MessageBox.Show(result);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
