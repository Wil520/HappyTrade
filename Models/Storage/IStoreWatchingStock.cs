using System;
using System.Collections.Generic;

using HappyTrade.Models.Engine;

namespace HappyTrade.Models.Storage
{
    public interface IStoreWatchingStock
    {

         void InsertWatchingStock(WatchingStock stock);


         List<WatchingStock> GetAllWatchingStocks(Guid userId);
         
         void DeleteWatchingStock(string symbol, Guid userId);
     
        
    }
}