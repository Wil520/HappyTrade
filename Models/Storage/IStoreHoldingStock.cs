using System;
using System.Collections.Generic;

using HappyTrade.Models.Engine;

namespace HappyTrade.Models.Storage
{
    public interface IStoreHoldingStock
    {

        void InsertHoldingStock(HoldingStock stock);

        void UpdateHoldingStock(HoldingStock stock);

        List<HoldingStock> GetAllHoldingStocks(Guid userId);

        void DeleteHoldingStock(string symbol, Guid userId);


    }
}