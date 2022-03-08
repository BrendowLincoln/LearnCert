using LearnCert.Api.Domain.Book;
using Microsoft.AspNetCore.Mvc;
using ISession = NHibernate.ISession;

namespace LearnCert.Api.Controllers
{
    
    [Route("WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "aaaaaa", "aaaaaaaa", "aaaaaaaa", "aaaaaaaaaa", "aaaaaaaaaa", "2222", "aaaaaaaa", "sasda", "aaaaaaaaaa", "vvvvv"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBookReadRepository _bookReadRepository;
        
        public WeatherForecastController(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }
        
        [HttpGet]
        [Route("Index")]
        public IList<Book> Index()
        {
            var list = _bookReadRepository.GetBooks().ToList();
            return list;
        }
        
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}