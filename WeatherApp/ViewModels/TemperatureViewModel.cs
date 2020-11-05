using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace WeatherApp.ViewModels
{
    public class TemperatureViewModel : BaseViewModel
    {
        


        public double CelsiusInFahrenheit(double c)
        {

            double f = (c * 1.8) + 32;
            f = Math.Round(f, 1);
            return f;
            
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
