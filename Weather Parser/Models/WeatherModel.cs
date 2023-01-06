namespace Weather_Parser.Models;

public class WeatherModel
{
    public Coordinates Coordinates { get; set; }
    public MainInforamtion Main { get; set; }
    public Wind Wind { get; set; }
}

public class Wind
{
    public string Speed { get; set; }
}

public class Coordinates
{ 
    public string City { get; set; }
    public string Country { get; set; }
    public string Lat { get; set; }
    public string Lon { get; set; }
}
public class MainInforamtion
{
    public int Degreeth { get; set; }
    public int FeelsLikeDegreeth { get; set; }
    public int MinDegreeth { get; set; }
    public int MaxDegreeth { get; set; }
    public string Pressure { get; set; }
    public string Humidity { get; set; }
}
