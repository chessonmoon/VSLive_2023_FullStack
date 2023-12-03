// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - WeatherForecastController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IAppLogging<WeatherForecastController> logger) : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpGet("test")]
    public IActionResult TestErrorMapping()
    {
        //logger.LogAppError("Test error");
        return NotFound();
    }

    [HttpGet("error")]
    public IActionResult TestExceptionHandling()
    {
        throw new Exception("Test Exception");
    }


}
