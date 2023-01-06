using AngleSharp;
using Weather_Parser.Interfaces;

namespace Weather_Parser.Implemantations;

public class ParserWeather : IParserWeather
{
    private readonly IBrowsingContext context = BrowsingContext.New(Configuration
															.Default.WithDefaultLoader()
															.WithDefaultCookies());
    public async Task<string> GetCityData(string searchString)
    {
		try
		{
			//await context.OpenAsync(searchString);
			return "a";
		}
		catch (Exception ex)
		{

			throw;
		}
		
    }

    private void lementedException()
    {
        throw new NotImplementedException();
    }
}
