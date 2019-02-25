using System;
using System.Collections.Generic;

namespace Module3Before
{
    class StockTrader : IStockTrader
    {
        List<InvestmentQuery> stocksToTrade = new List<InvestmentQuery>();

        public void EnqueueStockForTrading(InvestmentQuery query)
        {
            stocksToTrade.Add(query);
        }

        public void HandledTradings()
        {
            Console.Write(" [{0} stocks] ", stocksToTrade.Count);
            while(stocksToTrade.Count > 0)
            {
                var query = stocksToTrade[0];
                // As this is simulation of a real service that consumes queries as they arrive,
                // remember to remove the query from the list when processed: 
                stocksToTrade.RemoveAt(0);
                
                // Simulate stock trade:
//                Thread.Sleep(100);
            }
        }
    }
}
