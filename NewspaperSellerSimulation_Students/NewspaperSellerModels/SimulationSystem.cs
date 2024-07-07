using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            DayTypeDistributions = new List<DayTypeDistribution>();
            DemandDistributions = new List<DemandDistribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }
        ///////////// INPUTS /////////////
        public int NumOfNewspapers { get; set; }
        public int NumOfRecords { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal ScrapPrice { get; set; }
        public decimal UnitProfit { get; set; }
        public List<DayTypeDistribution> DayTypeDistributions { get; set; }
        public List<DemandDistribution> DemandDistributions { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }



        public void fillTable()
        {

            decimal buyingCost = 0;
            decimal sellingProfit = 0;
            decimal scrapProfit = 0;
            decimal lostProfit = 0;
            decimal netProfit = 0;
            Random rnd = new Random();

            for (int i = 1; i <= NumOfRecords; i++)
            {
                buyingCost = NumOfNewspapers * PurchasePrice;
                SimulationCase sc = new SimulationCase();
                sc.DayNo = i;
                sc.RandomNewsDayType = rnd.Next(1, 100);

                for (int j = 0; j < DayTypeDistributions.Count; j++)
                {
                    if (sc.RandomNewsDayType >= DayTypeDistributions[j].MinRange &&
                       sc.RandomNewsDayType <= DayTypeDistributions[j].MaxRange)
                    {
                        sc.NewsDayType = DayTypeDistributions[j].DayType;
                    }
                }

                sc.RandomDemand = rnd.Next(1, 100);
                for (int k = 0; k < DemandDistributions.Count; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        if (sc.NewsDayType == DemandDistributions[k].DayTypeDistributions[l].DayType &&
                           sc.RandomDemand >= DemandDistributions[k].DayTypeDistributions[l].MinRange &&
                           sc.RandomDemand <= DemandDistributions[k].DayTypeDistributions[l].MaxRange)
                        {
                            sc.Demand = DemandDistributions[k].Demand;
                        }
                    }
                }

                if (sc.Demand <= NumOfNewspapers)
                {
                    sellingProfit = sc.Demand * SellingPrice;
                    scrapProfit = (NumOfNewspapers - sc.Demand) * ScrapPrice;
                    lostProfit = 0;
                }
                else
                {
                    sellingProfit = NumOfNewspapers * SellingPrice;
                    scrapProfit = 0;
                    lostProfit = (sc.Demand - NumOfNewspapers) * (SellingPrice - PurchasePrice);
                }

                netProfit = sellingProfit - buyingCost - lostProfit + scrapProfit;

                sc.SalesProfit = sellingProfit;
                sc.ScrapProfit = scrapProfit;
                sc.LostProfit = lostProfit;
                sc.DailyNetProfit = netProfit;
                sc.DailyCost = buyingCost;

                SimulationTable.Add(sc);
            }

            /* Performance Measures
               1.Total Sales Revenue
               2.Total Cost of Newspapers
               3.Total Lost Profit from Excess Demand
               4.Total Salvage from sale of Scrap papers
               5.Net Profit
               6.Number of days having excess demand
               7.Number of days having unsold papers  */


        }
        public void CalculatePerformanceMeasures()
        {
            foreach (var caseItem in SimulationTable)
            {
                PerformanceMeasures.TotalSalesProfit += caseItem.SalesProfit;
                PerformanceMeasures.TotalCost += caseItem.DailyCost;
                PerformanceMeasures.TotalLostProfit += caseItem.LostProfit;
                PerformanceMeasures.TotalScrapProfit += caseItem.ScrapProfit;
                PerformanceMeasures.TotalNetProfit += caseItem.DailyNetProfit;

                if (caseItem.Demand > NumOfNewspapers)
                {
                    PerformanceMeasures.DaysWithMoreDemand++;

                }

                if (caseItem.Demand < NumOfNewspapers)
                {
                    PerformanceMeasures.DaysWithUnsoldPapers++;
                }
            }
        }
    }
}//----- Done
//------ Done
