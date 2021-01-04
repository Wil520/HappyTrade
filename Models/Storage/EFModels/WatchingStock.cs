using System;

namespace HappyTrade.Models.Storage.EFModels
{
    public class WatchingStock
    {
        public Guid WatchingStockId { get; set; }
        public Guid UserId { get; set; }
        public string Symbol { get; set; }
    }
}