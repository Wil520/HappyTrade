using System;

namespace HappyTrade.Models.Engine
{
    public class HoldingStock
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Shares { get; set; }
        public decimal AveragePrice { get; set; }

    }
}