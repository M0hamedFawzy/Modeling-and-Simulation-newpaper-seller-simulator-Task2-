using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class SharedData
    {
        public static string FileName { get; set; }
        public static bool checkIfSimulationIsPerformed { get; set; }
        public static SimulationSystem system { get; set; }
    }
}
