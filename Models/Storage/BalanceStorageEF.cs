using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using HappyTrade.Models.Engine;

namespace HappyTrade.Models.Storage
{
    public class BalanceStorageEF : IStoreBalance
    {

        private readonly ApplicationDbContext _context;

        public BalanceStorageEF(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InsertBalance(Balance balance)
        {
            var balanceDb = ConvertToDb(balance);
            _context.Balances.Add(balanceDb);
            _context.SaveChanges();

        }


        public List<Balance> GetAllBalances(Guid userId)
        {
            return _context.Balances
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => ConvertFromDb(x))
                .ToList();
        }

        private static Balance ConvertFromDb(EFModels.Balance balanceDb)
        {
            return new Balance()
            {
                Id = balanceDb.BalanceId,
                Fund = balanceDb.Fund,
                UserId = balanceDb.UserId,
                BalanceTime = balanceDb.BalanceTime
            };
        }

        private static EFModels.Balance ConvertToDb(Balance balance) {
            return new EFModels.Balance() {
                BalanceId = balance.Id,
                UserId = balance.UserId,
                Fund = balance.Fund,
                BalanceTime = balance.BalanceTime
            };
        }

    }
}