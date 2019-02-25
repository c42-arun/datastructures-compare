using System;
using System.Collections.Generic;

namespace Module3Before
{
    class RatingCacheElement
    {
        public string StockID { get; set; }
        public int Rating { get; set; }
    }

    class InvestmentAnalyzer
    {
        IStockTrader stockTrader;
        List<InvestmentQuery> queries = new List<InvestmentQuery>();
        List<RatingCacheElement> stock2rating = new List<RatingCacheElement>();
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
                var query = GetFirstPriority(queries); // Get first-priority queries first

                var cacheElement = stock2rating.Find(x => x.StockID == query.StockID);
                if (cacheElement != null)
                    rating = cacheElement.Rating;
                else
                {
                    rating = CalculateRating(query.StockID);
                    stock2rating.Add(
                        new RatingCacheElement { StockID = query.StockID, Rating = rating }
                    );
                }

                if (rating > 80) // Let's say that a rating of 80 triggers a stock trade
                    stockTrader.EnqueueStockForTrading(query);
            }
        }

        private InvestmentQuery GetFirstPriority(List<InvestmentQuery> queries)
        {
            InvestmentQuery minQuery = null;
            foreach(var query in queries)
            {
                if (minQuery == null || query.CompareTo(minQuery) < 0)
                    minQuery = query;
            }
            queries.Remove(minQuery);
            return minQuery;
        }

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
