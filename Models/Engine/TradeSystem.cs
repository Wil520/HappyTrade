using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using HappyTrade.Models.Storage;

namespace HappyTrade.Models.Engine
{
    public class TradeSystem
    {

        private readonly IStoreWatchingStock _watchingStockStorage;
        private readonly IStoreHoldingStock _holdingStockStorage;
        private readonly IStoreBalance _balanceStorage;
        private readonly IStoreTransaction _transactionStorage;


        public TradeSystem(IStoreWatchingStock watchingStockStorage, IStoreHoldingStock holdingStockStorage, IStoreBalance balanceStorage, IStoreTransaction transactionStorage)
        {
            _watchingStockStorage = watchingStockStorage;
            _holdingStockStorage = holdingStockStorage;
            _balanceStorage = balanceStorage;
            _transactionStorage = transactionStorage;
        }

        public bool IsWatching(string symbol, Guid userId)
        {

            var watchingStock = _watchingStockStorage.GetAllWatchingStocks(userId).Where(x => x.Symbol == symbol);
            return watchingStock != null && watchingStock.Count() > 0;
        }
        public string GetAllWatchingStockJson(Guid userId)
        {

            var arrWatchingStock = _watchingStockStorage.GetAllWatchingStocks(userId).Select(x => { return x.Symbol; }).ToArray();
            return JsonConvert.SerializeObject(arrWatchingStock);
        }


        public void AddWatching(string symbol, Guid userId)
        {

            bool isWatching = this.IsWatching(symbol, userId);
            if (!isWatching)
            {
                WatchingStock stock = new WatchingStock
                {
                    Id = Guid.NewGuid(),
                    Symbol = symbol,
                    UserId = userId
                };
                _watchingStockStorage.InsertWatchingStock(stock);
            }

        }

        public void RemoveWatching(string symbol, Guid userId)
        {

            bool isWatching = this.IsWatching(symbol, userId);
            if (isWatching)
            {
                _watchingStockStorage.DeleteWatchingStock(symbol,userId);
            }

        }        

    }
}