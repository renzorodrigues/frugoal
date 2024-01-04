using Microsoft.AspNetCore.Mvc;

namespace frugoal.API.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController()
    {
        //_logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(11, 20),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("/id")]
    public string Soma(string y, string x)
    {
        int a;
        int b;

        if (!int.TryParse(y, out a))
            return "Invalid parameters";

        if (!int.TryParse(x, out b))
            return "Invalid parameters";

        return (a+b).ToString();
    }
}
