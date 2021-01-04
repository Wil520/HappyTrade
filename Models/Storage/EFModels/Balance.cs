using System;

namespace HappyTrade.Models.Storage.EFModels
{
    public class Balance
    {
        public Guid BalanceId { get; set; }
        public Guid UserId { get; set; }
        public decimal Fund { get; set; }
        public DateTime BalanceTime { get; set; }

    }
}