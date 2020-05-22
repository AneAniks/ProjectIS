using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProjectIS.Models;

namespace ProjectIS.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherServiceConfig apiKey;

        public WeatherService(IOptions<WeatherServiceConfig> option)
        {
            this.apiKey = option.Value;
        }
        public async Task<Weather> GetCityByName(string name)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org");

            var response = await client.GetAsync($"/data/2.5/weather?q={name}&appid={apiKey.ApiKey}&units=metric");
             response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            WeatherResponse rawWeather = JsonConvert.DeserializeObject<WeatherResponse>(result);
            Weather openWeather = new Weather(DateTime.Now.ToString(), rawWeather.Id, rawWeather.Main.Temp, rawWeather.Main.Pressure, string.Join(",", rawWeather.Weather.Select(x => x.Main)), rawWeather.Name);
            client.Dispose();
            return openWeather;
        }
    }
}
