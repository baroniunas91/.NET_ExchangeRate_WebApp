using ExchangeRate.WebApp.Models;
using ExchangeRate.WebApp.Services;
using LtBankas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ExchangeRate.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ItemService _itemService;

        public HomeController(ItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetExchangeRates(RegisterDate model)
        {
            if(ModelState.IsValid)
            {
                if (model.Date > new DateTime(2014,01,01))
                {
                    TempData["MsgChangeStatus"] = "Date should be up to 2014-01-01!";
                    return View("Index");
                }
                var client = new ExchangeRatesSoapClient(ExchangeRatesSoapClient.EndpointConfiguration.ExchangeRatesSoap);
                var response = await client.getExchangeRatesByDate_XmlStringAsync(model.Date.ToString("MMMM dd, yyyy"));

                var itemsList = _itemService.ParseXmlNode(response);
                _itemService.SortByRate(itemsList);
                
                return View(itemsList);
            }
            else
            {
                TempData["MsgChangeStatus"] = "Date is invalid!";
                return View("Index");
            }
        }
    }
}
