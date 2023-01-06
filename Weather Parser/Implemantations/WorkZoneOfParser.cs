using AngleSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog.Fluent;
using System.Globalization;
using Weather_Parser.Interfaces;
using Weather_Parser.Models;

namespace Weather_Parser.Implemantations;

public class WorkZoneOfParser
{
    //private ILogger<WorkZoneOfParser> _logger;
    private readonly IBrowsingContext _context;
    private readonly string _url;


    public WorkZoneOfParser(IParserSetting setting) 
    {
        _context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
        _url = $"{setting.BaseUrl}/{setting.Prefix}/{setting.Value}";
    }
    public async Task<WeatherModel> GetCoordinatesCityByName(string city)
    {
        try
        {
            var jsonResponse = await _context.OpenAsync(_url);
            var bufferArray = (JArray)JsonConvert.DeserializeObject(jsonResponse.Body.QuerySelector("pre").TextContent);
            if (bufferArray.First is null)
                return null;

            var response = (JObject)bufferArray[0];

            return new WeatherModel
            {
                Coordinates = new Coordinates()
                {
                    Country = response["country"].ToString(),
                    City = response["name"].ToString(),
                    Lat = response["lat"].ToString(),
                    Lon = response["lon"].ToString()
                }         
            };
        }
        catch (Exception ex)
        {
      //      _logger.LogError($"WorkZoneOfParser Method GetCoordinatesCityByName: {ex.ToString()}");
            return null;
        }
    }
    public async Task<WeatherModel> GetWeatherByCoordinates(WeatherModel model)
    {
        try
        {
            var jsonResponse = await _context.OpenAsync(_url);
            string test = "[" + jsonResponse.Body.QuerySelector("pre").TextContent + "]";
            var bufferArray = (JArray)JsonConvert.DeserializeObject(test);
            var response = (JObject)bufferArray[0];
            var main = response["main"];
            var wind = response["wind"];

            return new WeatherModel
            {
                Coordinates = model.Coordinates,
                Main = new MainInforamtion
                {

                    Degreeth = ConvertingKelvinToCelsius(float.Parse(main["temp"].ToString())),
                    MinDegreeth = ConvertingKelvinToCelsius(float.Parse(main["temp_min"].ToString())),
                    MaxDegreeth = ConvertingKelvinToCelsius(float.Parse(main["temp_max"].ToString())),
                    FeelsLikeDegreeth = ConvertingKelvinToCelsius(float.Parse(main["feels_like"].ToString())),
                    Pressure = main["pressure"].ToString(),
                    Humidity = main["humidity"].ToString()
                },
                Wind = new Wind
                {
                    Speed = wind["speed"].ToString()
                }
            };
            
        }
        catch (Exception ex)
        {
        //    _logger.LogError($"WorkZoneOfParser Method GetWeatherByCoordinates: {ex.ToString()}");
            return null;
        }
    }


    private int ConvertingKelvinToCelsius(float kelvin)
    {
        return Convert.ToInt32(kelvin - 273.15f);
    }

}
