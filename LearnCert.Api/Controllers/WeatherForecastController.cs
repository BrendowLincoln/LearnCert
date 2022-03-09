using LearnCert.Domain;
using Microsoft.AspNetCore.Mvc;


[Route("WeatherForecast")]
public class WeatherForecastController : ControllerBase
{

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
        
}