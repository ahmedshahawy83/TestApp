using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Option
    {
        public int Cost { get; set; }
        public double Reliability { get; set; }
        public double Performance { get; set; }
        public int CostWeight { get; set; }
        public int ReliabilityWeight { get; set; }
        public int PerformanceWeight { get; set; }       
    }
}
