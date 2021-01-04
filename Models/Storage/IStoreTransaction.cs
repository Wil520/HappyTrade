using System;
using System.Collections.Generic;

using HappyTrade.Models.Engine;

namespace HappyTrade.Models.Storage
{
    public interface IStoreTransaction
    {

         void InsertTransaction(Transaction transaction);


         List<Transaction> GetAllTransactions(Guid userId);
     
        
    }
}