using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Commands;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class TemperatureViewModel : BaseViewModel
    {
        /// TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet
       
        private TemperatureModel currentTemp;
        private string city;

        public ITemperatureService TemperatureService { get; private set; }

        public DelegateCommand<string> GetTempCommand { get; set; }

        public TemperatureModel CurrentTemp
        {
            get => currentTemp;
            set
            {
                currentTemp = value;
                OnPropertyChanged();
                OnPropertyChanged("RawText");
            }
        }

        private ObservableCollection<TemperatureModel> temperatures;

        public string Name { get; }

        public ObservableCollection<TemperatureModel> Temperatures
        {
            get { return temperatures; }
            set
            {
                temperatures = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;

                if (TemperatureService != null)
                {
                    TemperatureService.SetLocation(City);
                }

                OnPropertyChanged();
            }
        }

        private string _rawText;

        public string RawText
        {
            get
            {
                return _rawText;
            }
            set
            {
                _rawText = value;
                OnPropertyChanged();
            }

        }

        public TemperatureViewModel()
        {
            Name = this.GetType().Name;
            Temperatures = new ObservableCollection<TemperatureModel>();

            GetTempCommand = new DelegateCommand<string>(GetTemp, CanGetTemp);
        }


        public bool CanGetTemp(string obj)
        {
            return TemperatureService != null;
        }

        public void GetTemp(string obj)
        {
            if (TemperatureService == null) throw new NullReferenceException();

            _ = GetTempAsync();
        }

        public async Task GetTempAsync()
        {
            CurrentTemp = await TemperatureService.GetTempAsync();

            if (CurrentTemp != null)
            {
                if (Temperatures.Count > 0)
                {
                    if (CurrentTemp.DateTime != Temperatures[0].DateTime && CurrentTemp.City != Temperatures[0].City)
                    {
                        Temperatures.Insert(0, CurrentTemp);
                    }
                }
                else Temperatures.Add(CurrentTemp);
                Debug.WriteLine(CurrentTemp);
            }
        }

        public double CelsiusInFahrenheit(double c)
        {
            return c * 9.0 / 5.0 + 32;
        }

        public double FahrenheitInCelsius(double f)
        {
            return (f - 32) * 5.0 / 9.0;
        }

        public void SetTemperatureService(ITemperatureService srv)
        {
            TemperatureService = srv;
        }
    }
}
