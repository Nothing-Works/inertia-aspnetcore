using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InertiaAdapter;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using react.Models;

namespace react.Controllers
{
    public class ForecastController : Controller
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public ForecastController()
        {
        }

        public IActionResult Index()
        {
            var rng = new Random();
            var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            //your js component file name.
            var componentName = "Forecast";
            //return whatever you want.
            var data = new { forecast };
            //return Inertia Result.
            return Inertia.Render(componentName, data);
        }
    }
}
