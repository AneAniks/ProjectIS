using System.Collections.Generic;
using ProjectIS.Models;

namespace ProjectIS.Services
{
    public class WeatherResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<WeatherDescription> Weather { get; set; }

        public Main Main { get; set; }
        public Sys Sys { get; set; }
    }
}
