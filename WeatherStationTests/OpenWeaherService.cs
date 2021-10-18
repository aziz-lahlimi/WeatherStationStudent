using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherStationTests
{
    internal class OpenWeaherService : IWindDataService
    {
        public Task<WindDataModel> GetDataAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}