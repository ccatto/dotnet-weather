using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using weatherCatto.Models;
using weatherCatto.Services;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace weatherCatto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public WeatherService _ws { get; set; }

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _ws = new WeatherService();
    }

    public IActionResult Index()
    {
        return View();
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

    public IActionResult WeatherResults(string id)
    {
        using (HttpClient client = new HttpClient())
        {
            string googAPIURL = "https://maps.googleapis.com/maps/api/geocode/json?key=AIzaSyC8kOfwLoyySLxxj0FJ3hHpS7JAaKuKpeM&components=postal_code:" + id;
            client.BaseAddress = new Uri(googAPIURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpResponseMessage response = client.GetAsync(googAPIURL).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent content = response.Content)
                    {
                        var contentSimple = content;
                        var Content = content.ReadAsStringAsync();
                        var parsedResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Content.Result);
                        var resultString = Convert.ToString(parsedResult);
                        if (resultString != null)
                        {
                            dynamic data = JObject.Parse(resultString);
                            decimal latitude = data.results[0].geometry.location.lat;
                            decimal longitude = data.results[0].geometry.location.lng;      
                            string openWeatherURL = "https://api.openweathermap.org/data/2.5/weather?lat=" + latitude + "&lon=" + longitude + "&units=imperial&appid=800a3f8dc7a089347269a3957e059ee1";
                            WeatherData weatherResults = _ws.GetWeatherData(openWeatherURL).Result;
                            return View(weatherResults);
                        }
                    }
                }
                else
                {
                    return View(response.StatusCode + " - " + response.ReasonPhrase);
                }
            }
        }
        return View();
    }
}
