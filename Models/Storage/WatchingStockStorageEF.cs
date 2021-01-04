using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using HappyTrade.Models.Engine;

namespace HappyTrade.Models.Storage
{
    public class WatchingStockStorageEF : IStoreWatchingStock
    {

        private readonly ApplicationDbContext _context;

        public WatchingStockStorageEF(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InsertWatchingStock(WatchingStock stock)
        {
            var stockDb = ConvertToDb(stock);
            _context.WatchingStocks.Add(stockDb);
            _context.SaveChanges();

        }


        public List<WatchingStock> GetAllWatchingStocks(Guid userId)
        {
            return _context.WatchingStocks
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => ConvertFromDb(x))
                .ToList();
        }

        public void DeleteWatchingStock(string symbol, Guid userId)
        {
            var stockDb = _context.WatchingStocks
                             .First(x => x.UserId == userId && x.Symbol == symbol);
            _context.WatchingStocks.Remove(stockDb);
            _context.SaveChanges();
        }



        private static WatchingStock ConvertFromDb(EFModels.WatchingStock stockDb)
        {
            return new WatchingStock()
            {
                Id = stockDb.WatchingStockId,
                Symbol = stockDb.Symbol,
                UserId = stockDb.UserId
            };
        }

        private static EFModels.WatchingStock ConvertToDb(WatchingStock stock) {
            return new EFModels.WatchingStock() {
                WatchingStockId = stock.Id,
                UserId = stock.UserId,
                Symbol = stock.Symbol,
            };
        }

    }
}