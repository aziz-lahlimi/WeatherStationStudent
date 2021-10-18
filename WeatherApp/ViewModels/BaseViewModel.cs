using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeatherApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public void SetTemperatureService(global::WeatherStationTests.ITemoeratureService @object)
        //{
        //    throw new NotImplementedException();
        //}
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
