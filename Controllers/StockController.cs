using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using HappyTrade.Models.ViewModels;
using HappyTrade.Models.Engine;

namespace HappyTrade.Controllers
{
    public class StockController : Controller
    {

        private readonly TradeSystem _tradeSystem;
        public StockController(TradeSystem tradeSystem)
        {
            _tradeSystem = tradeSystem;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string id)
        {
            var stockViewModel = new StockViewModel()
            {
                Symbol = id
            };

            stockViewModel.IsWatching = _tradeSystem.IsWatching(id, UserId());

            return View("Details", stockViewModel);
        }


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
