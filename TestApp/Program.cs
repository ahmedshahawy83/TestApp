// See https://aka.ms/new-console-template for more information
using TestApp;

 List<Option> options = new List<Option>
        {
                 new Option { Cost = 500, Reliability = 0.95, Performance = 8.5, CostWeight =
                40, ReliabilityWeight = 30, PerformanceWeight = 30 },
                 new Option { Cost = 600, Reliability = 0.90, Performance = 9.0, CostWeight =
                50, ReliabilityWeight = 20, PerformanceWeight = 30 },
                 new Option { Cost = 450, Reliability = 0.92, Performance = 8.0, CostWeight =
                30, ReliabilityWeight = 40, PerformanceWeight = 30 }
        };
int? bestOptionIndex = ChooseOption.ChooseBestOption(options);
Console.WriteLine($"Best Option is {bestOptionIndex ?? 0}");

