using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using WeatherApp.Commands;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    public class TemperatureViewModel : BaseViewModel
    {

        public ITemperatureService TemperatureService { get; set; }
        public DelegateCommand<string> GetTempCommand { get; set; }
        public TemperatureModel CurrentTemp { get; set; }

        public TemperatureViewModel()
        {
            GetTempCommand = new DelegateCommand<string>(GetTemp , CanGetTemp);
        }

        public double CelsiusInFahrenheit(double c)
        {

            double f = (c * 1.8) + 32;
            f = Math.Round(f, 1);
            return f;
            
        }

        public void SetTemperatureService(ITemperatureService temp)
        {
            TemperatureService = temp;
        }

        public void GetTemp(object o)
        {
            if(TemperatureService != null)
            {

            }
            else
            {
                throw new Exception { };
            }
            

        }
        public bool CanGetTemp(object o)
        {
            return TemperatureService != null ? true : false;
        }

        public double FahrenheitInCelsius(double f)
        {

            double c = (f - 32) / 1.8;
            c = Math.Round(c, 1);
            return c;


        }
        /// TODO : Ajoutez le code nécessaire pour réussir les tests et répondre aux requis du projet
    }
}
