using System;

namespace Module3Before
{
    class InvestmentQuery : IComparable<InvestmentQuery>
    {
        public string StockID { get; set; }
        public DateTime QueryTime { get; set; }
        public int Priority { get; set; }
        public Guid Investor { get; set; }

        public int CompareTo(InvestmentQuery other)
        {
            var priorityCompare = Priority.CompareTo(other.Priority);
            if (priorityCompare != 0)
                return priorityCompare;

            return QueryTime.CompareTo(other.QueryTime);
        }
    }
}
