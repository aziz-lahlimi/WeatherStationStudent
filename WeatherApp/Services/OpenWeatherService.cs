using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Services
{
    public class OpenWeatherService : IWindDataService
    {
        private object owp;

        public object WindDataService { get; private set; }

        public Task<WindDataModel> GetDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TemperatureModel> GetTempAsync()
        {
            throw new NotImplementedException();
        }

        public void SetLocation(string city)
        {
            throw new NotImplementedException();
        }

    }
}
