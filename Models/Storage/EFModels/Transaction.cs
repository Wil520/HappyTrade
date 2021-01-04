using System;

namespace HappyTrade.Models.Storage.EFModels
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid UserId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Shares { get; set; }
        public decimal Price { get; set; }
        public string Action { get; set; }
        public DateTime TransTime { get; set; }

    }
}