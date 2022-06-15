namespace API;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

//If Nullable is enabled in API.csproj string? needs to be there
    public string Summary { get; set; }
}
