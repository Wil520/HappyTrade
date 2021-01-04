using System;

namespace HappyTrade.Models.Engine
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Shares { get; set; }
        public decimal Price { get; set; }
        public string Action { get; set; }
        public DateTime TransTime { get; set; }

    }
}