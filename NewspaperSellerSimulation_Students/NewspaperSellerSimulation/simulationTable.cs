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
    public partial class simulationTable : Form
    {
        SimulationSystem system;
        int recordNumber = 0;
        string typeOfNewsDay = "";
        bool showBtn = false;
        public simulationTable()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            system = SharedData.system;
            recordNumber = system.NumOfRecords;
            dataGridView1.ReadOnly = true;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (showBtn == false)
            {
                for (int i = 0; i < recordNumber; i++)
                {
                    if (system.SimulationTable[i].NewsDayType == Enums.DayType.Good)
                    {
                        typeOfNewsDay = "Good";
                    }
                    if (system.SimulationTable[i].NewsDayType == Enums.DayType.Fair)
                    {
                        typeOfNewsDay = "Fair";
                    }
                    if (system.SimulationTable[i].NewsDayType == Enums.DayType.Poor)
                    {
                        typeOfNewsDay = "Poor";
                    }

                    dataGridView1.Rows.Add(
                                            system.SimulationTable[i].DayNo,
                                            system.SimulationTable[i].RandomNewsDayType,
                                            typeOfNewsDay,
                                            system.SimulationTable[i].RandomDemand,
                                            system.SimulationTable[i].Demand,
                                            system.SimulationTable[i].SalesProfit,
                                            system.SimulationTable[i].LostProfit,
                                            system.SimulationTable[i].ScrapProfit,
                                            system.SimulationTable[i].DailyNetProfit
                                         );
                }
                dataGridView1.Rows.Add(
                                            "",
                                            "",
                                            "",
                                            "",
                                            "",
                                            "===================================================",
                                            "===================================================",
                                            "===================================================",
                                            "==================================================="
                                         );
                dataGridView1.Rows.Add(
                                            "TOTAL:",
                                            "",
                                            "",
                                            "",
                                            "",
                                            system.PerformanceMeasures.TotalSalesProfit,
                                            system.PerformanceMeasures.TotalLostProfit,
                                            system.PerformanceMeasures.TotalScrapProfit,
                                            system.PerformanceMeasures.TotalNetProfit
                                         );
            }
            showBtn = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            showBtn = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if it's the desired column and the cell value is not null
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column9" && e.Value != null)
            {
                // Append a dollar sign to the end of the cell value
                
                e.Value = $"{e.Value} $";

                // Set the formatting applied flag to indicate it's handled
                e.FormattingApplied = true;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column8" && e.Value != null)
            {
                // Append a dollar sign to the end of the cell value
                e.Value = $"{e.Value} $";

                // Set the formatting applied flag to indicate it's handled
                e.FormattingApplied = true;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column7" && e.Value != null)
            {
                // Append a dollar sign to the end of the cell value
                e.Value = $"{e.Value} $";

                // Set the formatting applied flag to indicate it's handled
                e.FormattingApplied = true;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column6" && e.Value != null)
            {
                // Append a dollar sign to the end of the cell value
                e.Value = $"{e.Value} $";

                // Set the formatting applied flag to indicate it's handled
                e.FormattingApplied = true;
            }


            if (e.ColumnIndex == dataGridView1.Columns.Count - 1 && e.RowIndex >= 0)
            {
                
                object cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal netProfit))
                { 
                    if(netProfit > 0 && netProfit != system.PerformanceMeasures.TotalNetProfit)
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    if(netProfit == system.PerformanceMeasures.TotalNetProfit)
                    {
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    if(netProfit <= 0 && netProfit != system.PerformanceMeasures.TotalNetProfit)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                    e.FormattingApplied = true;
                }
            }

        }

        









        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void simulationTable_Load(object sender, EventArgs e)
        {

        }

        
    }
}
