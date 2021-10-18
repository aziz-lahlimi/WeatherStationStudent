using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class WindDataViewModel : BaseViewModel
    {

        public IWindDataService WindDataService;
        private WindDataModel currentData;

        public WindDataModel CurrentData
        {
            get { return currentData; }
            set
            {
                currentData = value;
                OnPropertyChanged();
            }
        }

        public object GetWindDataCommand { get; set; }
        public object CurrentTemp { get; set; }

        private DelegateCommandAsync<Task> GetDataCommand;

        public WindDataViewModel()
        {
            GetDataCommand = new DelegateCommandAsync<Task>(GetDataCommandFtc, CanGetData);
        }

        public static double KPHtoMPS(double kph)
        {
            double mps = kph * 1000 / 3600;
            mps = Math.Round(mps, 2);
            return mps;
        }
        public static double MPStoKPH(double mps)
        {
            double kph = mps * 3600 / 1000;
            kph = Math.Round(kph, 2);
            return kph;
        }

        public void SetWindDataService(IWindDataService windDataService)
        {
            WindDataService = windDataService;
        }

        public bool CanGetData()
        {
            return WindDataService == null ? false : true;
        }

        //Fonction des commandes
        public async Task GetDataCommandFtc()
        {
            if (WindDataService == null)
                throw new NullReferenceException();
            WindDataModel task = await WindDataService.GetDataAsync();
            CurrentData = task;
        }

        private class DelegateCommandAsync<T>
        {
            private Func<Task> getDataCommandFtc;
            private Func<bool> canGetData;

            public DelegateCommandAsync(Func<Task> getDataCommandFtc, Func<bool> canGetData)
            {
                this.getDataCommandFtc = getDataCommandFtc;
                this.canGetData = canGetData;
            }
        }

        /// TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet
    }
}
