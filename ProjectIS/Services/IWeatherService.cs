using System.Threading.Tasks;

namespace ProjectIS.Services
{
    public interface IWeatherService
    {
        public Task<Weather> GetCityByName(string name);
    }
}
