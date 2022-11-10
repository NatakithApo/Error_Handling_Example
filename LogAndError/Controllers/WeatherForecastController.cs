using Microsoft.AspNetCore.Mvc;

namespace LogAndError.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                string someResult = DoSomething();
            }
            /*catch (DivideByZeroException e)
            {
                _logger.LogError($"Zero {e.Message}");
            }*/
            catch (Exception e)
            {
                _logger.LogError($"Exception {e.Message}");
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // Get() -> DoSomething() -> DivideByZero()
        private string DoSomething()
        {
            try
            {
                //Add data many rows
            }
            catch(Exception e)
            {

                return "Catch";
            }
            finally
            {
                Console.WriteLine("abc");
            }

            return "Finish Dosomething";
        }

        private void DivideByZero()
        {
            //int zero = 0;
            //int b = 10 / zero;
            throw new DivideByZeroException("Intended Action.");
        }
    }
}