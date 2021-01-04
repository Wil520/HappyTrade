using System;
using System.Collections.Generic;

using HappyTrade.Models.Engine;

namespace HappyTrade.Models.Storage
{
    public interface IStoreBalance
    {

         void InsertBalance(Balance balance);


         List<Balance> GetAllBalances(Guid userId);
     
        
    }
}