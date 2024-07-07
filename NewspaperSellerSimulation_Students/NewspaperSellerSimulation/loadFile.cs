using MultiQueueModels;
using NewspaperSellerModels;
using NewspaperSellerTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewspaperSellerSimulation
{
    public partial class loadFile : Form
    {
        public String path = "";
        public loadFile()
        {
            InitializeComponent();
            SharedData.checkIfSimulationIsPerformed = false;
        }

        private void loadFile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {

                using (var openFileDialog = new OpenFileDialog())
                {
                    DialogResult result = openFileDialog.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                    {
                        // Update the Label text with the selected file path
                        textBox1.Text = openFileDialog.FileName;
                        path = textBox1.Text;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            path = textBox1.Text;
            SharedData.system = null;
            SharedData.FileName = "";
            SharedData.checkIfSimulationIsPerformed = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == String.Empty && path == string.Empty)
            {
                MessageBox.Show("     Nothing To Show! \nSelect the file path first\n        (づ｡◕‿‿◕｡)づ");
                
            }
            else
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                FileReader fileReader = new FileReader(path);
                SimulationSystem system = fileReader.LoadData();
                system.fillTable();
                system.CalculatePerformanceMeasures();
                string result = testManager(fileNameWithoutExtension, system);
                MessageBox.Show(result);
                SharedData.checkIfSimulationIsPerformed = true;
                SharedData.system = system;
                SharedData.FileName = fileNameWithoutExtension;
            }
        }

        private string testManager(string path, SimulationSystem system)
        {
            string result = "";

            if(path == "TestCase1")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase1);
            }
            if (path == "TestCase2")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase2);
            }
            if (path == "TestCase3")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase3);
            }
            if (path == "TestCase4")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase4);
            }
            if (path == "TestCase5")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase5);
            }
            if (path == "TestCase6")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase6);
            }
            if (path == "TestCase7")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase7);
            }
            if (path == "TestCase8")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase8);
            }
            if (path == "TestCase9")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase9);
            }
            if (path == "TestCase10")
            {
                result = TestingManager.Test(system, Constants.FileNames.TestCase10);
            }

            return result;
        }

        
    }
}
