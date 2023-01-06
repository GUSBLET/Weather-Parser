namespace Weather_Parser.Interfaces;

public interface IParserWeather
{
    public Task<string> GetCityData(string city);
}
