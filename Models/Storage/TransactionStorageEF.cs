using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using HappyTrade.Models.Engine;

namespace HappyTrade.Models.Storage
{
    public class TransactionStorageEF : IStoreTransaction
    {

        private readonly ApplicationDbContext _context;

        public TransactionStorageEF(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InsertTransaction(Transaction transaction)
        {
            var TransactionDb = ConvertToDb(transaction);
            _context.Transactions.Add(TransactionDb);
            _context.SaveChanges();

        }


        public List<Transaction> GetAllTransactions(Guid userId)
        {
            return _context.Transactions
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => ConvertFromDb(x))
                .ToList();
        }

        private static Transaction ConvertFromDb(EFModels.Transaction transactionDb)
        {
            return new Transaction()
            {
                Id = transactionDb.TransactionId,
                UserId = transactionDb.UserId,
                Symbol = transactionDb.Symbol,
                Name = transactionDb.Name,
                Shares = transactionDb.Shares,
                Price = transactionDb.Price,
                Action = transactionDb.Action,
                TransTime = transactionDb.TransTime
            };
        }

        private static EFModels.Transaction ConvertToDb(Transaction transaction) {
            return new EFModels.Transaction() {
                TransactionId = transaction.Id,
                UserId = transaction.UserId,
                Symbol = transaction.Symbol,
                Name = transaction.Name,
                Shares = transaction.Shares,
                Price = transaction.Price,
                Action = transaction.Action,
                TransTime = transaction.TransTime
            };
        }

    }
}