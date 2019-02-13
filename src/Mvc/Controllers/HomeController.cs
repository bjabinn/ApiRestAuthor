// ------------------------------------------------------
// <copyright company="Everis Centers S.L.U">
//     Copyright (c) Sevilla HPC. All rights reserved.
// </copyright>
// ------------------------------------------------------

using Everis.Polar.Mvc.Infrastructure;
using Everis.Polar.Mvc.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Everis.Polar.Mvc.ViewModels;
using Everis.Polar.Mvc.Models;

namespace Everis.Polar.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClient _httpClient;
        private readonly IOptions<AppSettings> _settings;
        private string _serviceUrl;


        public HomeController(IOptions<AppSettings> settings, IHttpClient httpClient)
        {
            _settings = settings;
            _httpClient = httpClient;

            _serviceUrl = $"{_settings.Value.Services.BaseUrl}/home";
        }


        // TODO: Uncomment to use Caching !!!
        // [ResponseCache(Duration =15, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Index()
        {
            return View();
        }

        private static HomeViewModel MapToViewModel()
        {
            return new HomeViewModel()
            {
                
            };
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}