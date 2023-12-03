// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - WeatherForecast.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/25
// ==================================

namespace AutoLot.Api;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
