using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.ViewModels;

namespace WeatherApp.Models
{
    public class WindDataModel
    {
        public double direction { get; set; }
        public double MetrePerSec { get; set; }
        public DateTime DateTime { get; set; }
        public object CurrentData { get; set; }

        public static implicit operator WindDataModel(WindDataViewModel v)
        {
            throw new NotImplementedException();
        }

        public void SetWinDataService(IWindDataService @object)
        {
            throw new NotImplementedException();
        }

        public void GetDataCfommandFtc()
        {
            throw new NotImplementedException();
        }
    }
}
