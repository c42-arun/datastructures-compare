using System;
using System.Diagnostics;

namespace Module3Before
{

    class Program
    {
        static Random random = new Random(29);
        static void Main(string[] args)
        {
            var stockTrader = new StockTrader();
            var analyzer = new InvestmentAnalyzer(stockTrader);
            var stopwatch = new Stopwatch();

            // Simulate queries:
            Console.Write("Querying... ");
            stopwatch.Start();
            for (var i = 0; i < 50000; i++)
                analyzer.HandleQuery(CreateQuery());
            Console.WriteLine("Done in {0} s", Math.Round(stopwatch.Elapsed.TotalSeconds, 2));

            // Simulate handling of queries:
            Console.Write("Analyzing queries... ");
            stopwatch.Restart();
            analyzer.AnalyzeQueries();
            Console.WriteLine("Done in {0} s", Math.Round(stopwatch.Elapsed.TotalSeconds, 2));

            // Simulate handling of stock tradings:
            Console.Write("Handling tradings... ");
            stopwatch.Restart();
            stockTrader.HandledTradings();
            Console.WriteLine("Done in {0} s", Math.Round(stopwatch.Elapsed.TotalSeconds, 2));

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        static InvestmentQuery CreateQuery()
        {
            return new InvestmentQuery
            {
                StockID = "Stock" + random.Next(10000),
                QueryTime = DateTime.Now,
                Priority = random.Next(5),
                Investor = Guid.NewGuid()
            };
        }
    }
}
