using System;

namespace HappyTrade.Models.Storage.EFModels
{
    public class HoldingStock
    {
        public Guid HoldingStockId { get; set; }
        public Guid UserId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Shares { get; set; }
        public decimal AveragePrice { get; set; }

    }
}