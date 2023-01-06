using Weather_Parser.Interfaces;

namespace Weather_Parser.Implemantations;

public class ParserSetting : IParserSetting
{
    public string BaseUrl { get; set; }
    public string Prefix { get; set; }
    public string TokenApi { get; set; }
    public string Value { get; set; }

    public ParserSetting(string baseUrl, string prefix, string value, string tokenApi)
    {
        BaseUrl = baseUrl;
        Prefix = prefix;
        Value = value;
        TokenApi = tokenApi;
    }
}
