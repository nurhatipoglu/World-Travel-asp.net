using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorldTravel.Services;
using WorldTravel.Models;
using Microsoft.Extensions.Logging;

namespace WorldTravel.Pages.navbarPages
{
    public class ShowCityModel : PageModel
    {

        // Status durumu ba�ar�l� veya hatal� i�lemlerde d�nd�r�len yaz� i�in kullan�l�yor.
        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        private readonly ILogger<ShowCityModel> _logger;

        public JsonCityService JsonCityService;

        public IEnumerable<CityModel> Cities;

        public ShowCityModel(ILogger<ShowCityModel> logger, JsonCityService jsoncityservice)
        {
            _logger = logger;
            JsonCityService = jsoncityservice;
        }

        // Sayfa a��l�nca Cities adl� de�i�kene Getcity() fonksiyonu t�m �ehirleri d�nd�r�yor.
        public void OnGet()
        {
            Cities = JsonCityService.GetCity();

        }
    }
}


