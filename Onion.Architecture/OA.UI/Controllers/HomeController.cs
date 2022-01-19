using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OA.Core.Interfaces;
using OA.Data;
using System.Collections.Generic;
using System.Diagnostics;

namespace OA.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _api;

        public HomeController(ILogger<HomeController> logger,
            IApiService api)
        {
            _logger = logger;
            _api = api;
        }

        public IActionResult Index()
        {
            Debugger.Break();
            var customers = _api.Get<IEnumerable<Customer>>(null, "api/customer");

            return View();
        }
    }
}
