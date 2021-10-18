using System;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    internal class OpenWeatherProcessor
    {
        public static OpenWeatherProcessor Instance { get; internal set; }
        public string ApiKey { get; internal set; }

        internal Task GetCurrentWeatherAsync()
        {
            throw new NotImplementedException();
        }
    }
}