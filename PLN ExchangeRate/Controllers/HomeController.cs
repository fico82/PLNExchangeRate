using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PLN_ExchangeRate.Models;
using PLNExchangeRate.Data.Models;
using PLNExchangeRate.Service;
using PLNExchangeRate.Data;

namespace PLN_ExchangeRate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExchange EService = new ExchangeService();

        public async Task <IActionResult> Index()
        {
            var deserializedEUR = new Root();
            var deserializedUSD = new Root();

            deserializedEUR = await EService.GetExchange("eur");
            deserializedUSD = await EService.GetExchange("usd");

            var model = new ExchangeModel
            {
                effectiveDateUSD = deserializedUSD.rates[0].effectiveDate,
                midUSD = deserializedUSD.rates[0].mid,
                effectiveDateUSD1 = deserializedUSD.rates[1].effectiveDate,
                midUSD1 = deserializedUSD.rates[1].mid,
                changeUSD = EService.GetChange(deserializedUSD.rates[0].mid, deserializedUSD.rates[1].mid),

                effectiveDateEUR = deserializedUSD.rates[0].effectiveDate,
                midEUR = deserializedEUR.rates[0].mid,
                effectiveDateEUR1 = deserializedUSD.rates[1].effectiveDate,
                midEUR1 = deserializedEUR.rates[1].mid,
                changeEUR = EService.GetChange(deserializedEUR.rates[0].mid, deserializedEUR.rates[1].mid),
            };

            return View(model);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
