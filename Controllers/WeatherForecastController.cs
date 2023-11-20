using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
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
        /*Этот код определяет контроллер WeatherForecastController, который предоставляет метод Get для получения коллекции прогнозов погоды.

Атрибуты [ApiController] и [Route("[controller]")] определяют, что контроллер является API-контроллером и что маршрут к этому контроллеру будет строиться на основе имени контроллера. В данном случае маршрут будет иметь вид "/WeatherForecast".

Конструктор контроллера принимает объект ILogger<WeatherForecastController>, который может использоваться для записи логов.

Метод Get выполняет запрос на получение коллекции прогнозов погоды. В данном примере метод возвращает коллекцию из пяти прогнозов, созданных с помощью метода Enumerable.Range, который создает последовательность чисел в указанном диапазоне, а также с помощью генератора случайных чисел Random. Каждый прогноз имеет свойства Date, TemperatureC и Summary, которые были заполнены случайными значениями. Возвращаемая коллекция прогнозов сериализуется в формат JSON и отправляется клиентскому приложению.*/
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
