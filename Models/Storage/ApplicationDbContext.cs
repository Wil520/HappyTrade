using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using HappyTrade.Models.Storage.EFModels;

namespace HappyTrade.Models.Storage
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            // Empty constructor body...
        }


        public DbSet<WatchingStock> WatchingStocks { get; set; }
        public DbSet<HoldingStock> HoldingStocks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Balance> Balances { get; set; }
        
    }
}