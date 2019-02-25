namespace Module3Before
{
    interface IStockTrader
    {
        void EnqueueStockForTrading(InvestmentQuery query);
        void HandledTradings();
    }
}