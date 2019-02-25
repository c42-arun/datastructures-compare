using System;
using System.Collections.Generic;

namespace Module3Before
{
    //class RatingCacheElement
    //{
    //    public string StockID { get; set; }
    //    public int Rating { get; set; }
    //}

    class InvestmentAnalyzer
    {
        IStockTrader stockTrader;
        C5.IntervalHeap<InvestmentQuery> queries = new C5.IntervalHeap<InvestmentQuery>();
        Dictionary<string, int> stock2rating = new Dictionary<string, int>();
        Random random = new Random(29);

        public InvestmentAnalyzer(IStockTrader stockTrader)
        {
            this.stockTrader = stockTrader;
        }

        public void HandleQuery(InvestmentQuery query)
        {
            queries.Add(query);
        }

        public void AnalyzeQueries()
        {
            while(queries.Count > 0)
            {
                int rating;
                var query = queries.DeleteMin(); // Get first-priority queries first

                //var cacheElement = stock2rating.Find(x => x.StockID == query.StockID);
                if (stock2rating.ContainsKey(query.StockID))
                    rating = stock2rating[query.StockID];
                else
                {
                    rating = CalculateRating(query.StockID);
                    stock2rating.Add(query.StockID, rating);
                }

                if (rating > 80) // Let's say that a rating of 80 triggers a stock trade
                    stockTrader.EnqueueStockForTrading(query);
            }
        }

        //private InvestmentQuery GetFirstPriority(List<InvestmentQuery> queries)
        //{
        //    InvestmentQuery minQuery = null;
        //    foreach(var query in queries)
        //    {
        //        if (minQuery == null || query.CompareTo(minQuery) < 0)
        //            minQuery = query;
        //    }
        //    queries.Remove(minQuery);
        //    return minQuery;
        //}

        int CalculateRating(string stockID)
        {
            // Simulate some computation time that might involve
            // fetching data from various external data sources:
//            Thread.Sleep(100);

            // Simulate some calculation result:
            return random.Next(100);
        }
    }
}
