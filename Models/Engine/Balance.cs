using System;

namespace HappyTrade.Models.Engine
{
    public class Balance
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Fund { get; set; }
        public DateTime BalanceTime { get; set; }

    }
}