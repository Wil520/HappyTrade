using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using HappyTrade.Models.ViewModels;
using HappyTrade.Models.Engine;

namespace HappyTrade.Controllers
{
    public class WatchlistController : Controller
    {

        private readonly TradeSystem _tradeSystem;
        public WatchlistController(TradeSystem tradeSystem)
        {
            _tradeSystem = tradeSystem;
        }

        public IActionResult Index()
        {
            WatchlistViewModel watchlistViewModel = new WatchlistViewModel();
            watchlistViewModel.WatchingStockJson = _tradeSystem.GetAllWatchingStockJson(UserId());
            return View(watchlistViewModel);
        }

        public IActionResult Watch(StockViewModel stockViewModel)
        {

            _tradeSystem.AddWatching(stockViewModel.Symbol, UserId());
            
            return RedirectToAction("Index");
        }

        public IActionResult Unwatch(StockViewModel stockViewModel)
        {

            _tradeSystem.RemoveWatching(stockViewModel.Symbol, UserId());
            
            return RedirectToAction("Index");
        }        

        // public IActionResult Details(string id)
        // {
        //     var stockViewModel = new StockViewModel()
        //     {
        //         Symbol = id
        //     };

        //     stockViewModel.IsWatching = _tradeSystem.isWatching(id, UserId());
            
        //     return View("Details", stockViewModel);
        // }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Guid UserId() {
            // string stringUserId = _userManager.GetUserId(User);
            return Guid.Parse("eeb60a9c-b66e-4126-9b85-58c022894e02");
        }        
    }
}
