using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class DemandDistribution
    {
        public DemandDistribution()
        {
            DayTypeDistributions = new List<DayTypeDistribution>();
        }

        public DemandDistribution(int demand, List<DayTypeDistribution> d)
        {
            this.Demand = demand;
            this.DayTypeDistributions = d;
        }

        public int Demand { get; set; }
        public List<DayTypeDistribution> DayTypeDistributions { get; set; }
    }
}