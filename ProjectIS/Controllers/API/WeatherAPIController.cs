using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjectIS.Services;

namespace ProjectIS.Controllers.API
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherAPIController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly IConfiguration _con;
        public WeatherAPIController(IConfiguration con, IWeatherService weatherService)
        {
            this._con = con;
           this._weatherService = weatherService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Weather>> GetCity(string name)
        {
            string apiKey = _con.GetSection("ApiKey").Value;
            Weather result;
            try
            {
              //  WeatherService openWeather = new WeatherService(apiKey);
                result = await _weatherService.GetCityByName(name);
            }
            catch (HttpRequestException httpRequestException)
            {

                return BadRequest(httpRequestException.Message);
            }
            return result;
        }
    }
}