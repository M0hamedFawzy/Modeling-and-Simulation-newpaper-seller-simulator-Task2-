using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiQueueModels;
using System;
using System.Collections.Generic;
using System.IO;
using NewspaperSellerModels;

namespace MultiQueueModels
{
    public class FileReader
    {
        string url;
        SimulationSystem system = new SimulationSystem();

        public FileReader(string url)
        {
            this.url = url;
        }
        public List<DemandDistribution> fillDemandDist(StreamReader read)
        {
            List<DemandDistribution> D = new List<DemandDistribution>();

            string line;

            while ((line = read.ReadLine()) != null)
            {
                
                string[] sep;
                sep = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                int demand = int.Parse(sep[0]);

                DayTypeDistribution d1 = new DayTypeDistribution();
                DayTypeDistribution d2 = new DayTypeDistribution();
                DayTypeDistribution d3 = new DayTypeDistribution();

                d1.DayType = Enums.DayType.Good;
                d2.DayType = Enums.DayType.Fair;
                d3.DayType = Enums.DayType.Poor;

                d1.Probability = decimal.Parse(sep[1]);
                d2.Probability = decimal.Parse(sep[2]);
                d3.Probability = decimal.Parse(sep[3]);

                if (D.Count() == 0)
                {
                    d1.CummProbability = decimal.Parse(sep[1]);
                    d2.CummProbability = decimal.Parse(sep[2]);
                    d3.CummProbability = decimal.Parse(sep[3]);
                    
                    d1.MinRange = 1;
                    d2.MinRange = 1;
                    d3.MinRange = 1;
                }
                else
                {
                    DemandDistribution last= D.Last();
                    d1.CummProbability = last.DayTypeDistributions[0].CummProbability + d1.Probability;
                    d2.CummProbability = last.DayTypeDistributions[1].CummProbability + d2.Probability;
                    d3.CummProbability = last.DayTypeDistributions[2].CummProbability + d3.Probability;

                    d1.MinRange = last.DayTypeDistributions[0].MaxRange + 1;
                    d2.MinRange = last.DayTypeDistributions[1].MaxRange + 1;
                    d3.MinRange = last.DayTypeDistributions[2].MaxRange + 1;
                }
                
                d1.MaxRange = Convert.ToInt32(d1.CummProbability * 100);
                d2.MaxRange = Convert.ToInt32(d2.CummProbability * 100);
                d3.MaxRange = Convert.ToInt32(d3.CummProbability * 100);

                List<DayTypeDistribution> d = new List<DayTypeDistribution> { d1, d2, d3 };

                D.Add(new DemandDistribution(demand, d));

            }
            return D;
        }

        public SimulationSystem LoadData()
        {
            SimulationSystem system = new SimulationSystem();
            using (StreamReader read = new StreamReader(url))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    if (line == "NumOfNewspapers") system.NumOfNewspapers = int.Parse(read.ReadLine());
                    else if (line == "NumOfRecords") system.NumOfRecords = int.Parse(read.ReadLine());
                    else if (line == "PurchasePrice") system.PurchasePrice = decimal.Parse(read.ReadLine());
                    else if (line == "ScrapPrice") system.ScrapPrice = decimal.Parse(read.ReadLine());
                    else if (line == "SellingPrice")
                    {
                        system.SellingPrice = decimal.Parse(read.ReadLine());
                        system.UnitProfit = system.SellingPrice - system.PurchasePrice;
                    }
                    else if (line == "DayTypeDistributions")
                    {
                        // good fair poor
                        line = read.ReadLine();
                        string[] DTDvalues= line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        DayTypeDistribution d1 = new DayTypeDistribution();
                        d1.DayType = Enums.DayType.Good;
                        d1.Probability = decimal.Parse(DTDvalues[0]);
                        d1.CummProbability = decimal.Parse(DTDvalues[0]);
                        d1.MinRange = 1;
                        d1.MaxRange = Convert.ToInt32(d1.CummProbability * 100);

                        DayTypeDistribution d2 = new DayTypeDistribution();

                        d2.DayType = Enums.DayType.Fair;
                        d2.Probability = decimal.Parse(DTDvalues[1]);
                        d2.CummProbability = d1.CummProbability + decimal.Parse(DTDvalues[1]);
                        d2.MinRange = d1.MaxRange + 1;
                        d2.MaxRange = Convert.ToInt32(d2.CummProbability * 100);

                        DayTypeDistribution d3 = new DayTypeDistribution();

                        d3.DayType = Enums.DayType.Poor;
                        d3.Probability = decimal.Parse(DTDvalues[2]);
                        d3.CummProbability = d2.CummProbability + decimal.Parse(DTDvalues[2]);
                        d3.MinRange = d2.MaxRange + 1;
                        d3.MaxRange = Convert.ToInt32(d3.CummProbability * 100);

                        system.DayTypeDistributions = new List<DayTypeDistribution> { d1, d2, d3 };

                    }
                    else if (line == "DemandDistributions") {
                        system.DemandDistributions = fillDemandDist(read);
                    }
                    else if (line == "" || line == " ") continue;
                }

            }
            return system;
        }
    }
}
//Done
