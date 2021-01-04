using System;

namespace HappyTrade.Models.Engine
{
    public class WatchingStock
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Symbol { get; set; }
    }
}