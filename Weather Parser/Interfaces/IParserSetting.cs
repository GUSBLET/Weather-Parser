namespace Weather_Parser.Interfaces;

public interface IParserSetting
{
    string BaseUrl { get; set; }
    string Prefix { get; set; }
    string Value { get; set; }
    string TokenApi { get; set; }
}
