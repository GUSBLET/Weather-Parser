using Microsoft.AspNetCore.Mvc;
using Weather_Parser.Implemantations;
using Microsoft.Extensions.Logging;
using Weather_Parser.Interfaces;
using Weather_Parser.Models;

namespace Weather_Parser.Controllers
{
    public class HomeController : Controller
    {
        private WorkZoneOfParser _workZoneOfParser;
        private readonly IParserSetting _parserSetting;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IConfiguration configuration,
            ILogger<HomeController> logger)
        {
            _parserSetting = new ParserSetting(
                                "https://api.openweathermap.org",
                                "geo/1.0",
                                "direct?q={city}&limit=1&appid={ApiToken}",
                                configuration.GetValue<string>("ApiToken"));
            _logger = logger;
        }

        public IActionResult Index()
        {           
            _logger.LogInformation("Hello, this is the index!");
            return View();
        }
        
        public async Task<IActionResult> Search(string city)
        {
            if (city != null && _parserSetting.TokenApi != null)
            {
                _parserSetting.Value = _parserSetting.Value.Replace("{city}", city).Replace("{ApiToken}", _parserSetting.TokenApi);
                _workZoneOfParser = new WorkZoneOfParser(_parserSetting);
                var model = _workZoneOfParser.GetCoordinatesCityByName(city);
                if (model.Result is null)
                    return RedirectToAction("Index");
                _parserSetting.Prefix = "data/2.5";
                _parserSetting.Value = $"weather?lat={model.Result.Coordinates.Lat}&lon={model.Result.Coordinates.Lon}&appid={_parserSetting.TokenApi}";
                _workZoneOfParser = new WorkZoneOfParser(_parserSetting);
                model = _workZoneOfParser.GetWeatherByCoordinates(model.Result);
                
                return View("Index", model.Result);
            }
            return RedirectToAction("Index");
        }
           
    }
}
