using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public interface IWindDataService
    {
        Task<WindDataModel> GetDataAsync();
    }
}