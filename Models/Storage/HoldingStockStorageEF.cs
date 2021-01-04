using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using HappyTrade.Models.Engine;

namespace HappyTrade.Models.Storage
{
    public class HoldingStockStorageEF : IStoreHoldingStock
    {

        private readonly ApplicationDbContext _context;

        public HoldingStockStorageEF(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InsertHoldingStock(HoldingStock stock)
        {
            var stockDb = ConvertToDb(stock);
            _context.HoldingStocks.Add(stockDb);
            _context.SaveChanges();

        }


        public List<HoldingStock> GetAllHoldingStocks(Guid userId)
        {
            return _context.HoldingStocks
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => ConvertFromDb(x))
                .ToList();
        }

        public void DeleteHoldingStock(string symbol, Guid userId)
        {
            var stockDb = _context.HoldingStocks
                             .First(x => x.UserId == userId && x.Symbol == symbol);
            _context.HoldingStocks.Remove(stockDb);
            _context.SaveChanges();
        }

        public void UpdateHoldingStock(HoldingStock stock)
        {
            var stockDb = ConvertToDb(stock);
            _context.HoldingStocks.Update(stockDb);
            _context.SaveChanges();
        }

        private static HoldingStock ConvertFromDb(EFModels.HoldingStock stockDb)
        {
            return new HoldingStock()
            {
                Id = stockDb.HoldingStockId,
                Symbol = stockDb.Symbol,
                UserId = stockDb.UserId,
                Name = stockDb.Name,
                Shares = stockDb.Shares,
                AveragePrice = stockDb.AveragePrice
            };
        }

        private static EFModels.HoldingStock ConvertToDb(HoldingStock stock) {
            return new EFModels.HoldingStock() {
                HoldingStockId = stock.Id,
                UserId = stock.UserId,
                Symbol = stock.Symbol,
                Name = stock.Name,
                Shares = stock.Shares,
                AveragePrice = stock.AveragePrice
            };
        }

    }
}