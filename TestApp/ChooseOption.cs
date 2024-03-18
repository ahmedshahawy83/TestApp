using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class  ChooseOption
    {
        public static List<CalculatedOption> CalculatedOption { get; set; }

        
        public static int? ChooseBestOption(List<Option> options)
        {
            CalculatedOption = options.Select(x => new CalculatedOption
            {
                Index = options.IndexOf(x) + 1,
                Cost = x.Cost * x.CostWeight / 100,
                Reliability = x.Reliability * x.ReliabilityWeight / 100,
                Performance = x.Performance * x.PerformanceWeight / 100
            }).ToList();


            int? index= Order(SetOptions())?.Index;
            return index;
        }
        public static CalculatedOption Order(Dictionary<string, Func<CalculatedOption, bool>> options)
        {
            CalculatedOption option=new ();
            foreach (var opt in options)
            {
                option = CalculatedOption.FirstOrDefault(opt.Value);
                if (option is not null)
                        return option;

            }
            //CalculatedOption option = CalculatedOption.FirstOrDefault(Exp);
            return option;
        }
        private static Dictionary<string, Func<CalculatedOption, bool>> SetOptions()
        {
          return  new Dictionary<string, Func<CalculatedOption, bool>>()
            {
                {"Three", x => x.Cost == CalculatedOption.Min(x => x.Cost) && x.Performance ==CalculatedOption.Max(x => x.Performance) && x.Reliability==CalculatedOption.Max(x => x.Reliability)},
                {"Two", x => x.Cost == CalculatedOption.Min(x => x.Cost) && (x.Performance ==CalculatedOption.Max(x => x.Performance) || x.Reliability==CalculatedOption.Max(x => x.Reliability))
                 || x.Performance == CalculatedOption.Max(x => x.Performance) && (x.Cost == CalculatedOption.Min(x => x.Cost) || x.Reliability==CalculatedOption.Max(x => x.Reliability))
                || x.Reliability==CalculatedOption.Max(x => x.Reliability) && (x.Cost == CalculatedOption.Min(x => x.Cost) || x.Performance == CalculatedOption.Max(x => x.Performance)) },
                {"One", x => x.Cost == CalculatedOption.Min(x => x.Cost) || x.Performance ==CalculatedOption.Max(x => x.Performance) || x.Reliability==CalculatedOption.Max(x => x.Reliability)}
            };
        }
    }
    public class CalculatedOption
    {
        public int Index { get; set; }
        public double Cost { get; set; }
        public double Reliability { get; set; }
        public double Performance { get; set; }
    }

}
