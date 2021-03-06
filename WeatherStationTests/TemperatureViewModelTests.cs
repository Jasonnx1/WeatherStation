﻿using Autofac.Extras.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.ViewModels;
using Xunit;
using Xunit.Sdk;

namespace WeatherStationTests
{
    public class TemperatureViewModelTests : IDisposable
    {
        // System Under Test
        // Utilisez ce membre dans les tests
        TemperatureViewModel _sut = new TemperatureViewModel();

        /// <summary>
        /// Test la fonctionnalité de conversion de Celsius à Fahrenheit
        /// </summary>
        /// <param name="C">Degré Celsius</param>
        /// <param name="expected">Résultat attendu</param>
        /// <remarks>T01</remarks>
        [Theory]
        [InlineData(0, 32)]
        [InlineData(-40, -40)]
        [InlineData(-20, -4)]
        [InlineData(-17.8, 0)]
        [InlineData(37, 98.6)]
        [InlineData(100, 212)]
        public void CelsiusInFahrenheit_AlwaysReturnGoodValue(double C, double expected)
        {
            TemperatureViewModel model = new TemperatureViewModel();

            double actual = model.CelsiusInFahrenheit(C);

            Assert.Equal(expected, actual);

        }

        /// <summary>
        /// Test la fonctionnalité de conversion de Fahrenheit à Celsius
        /// </summary>
        /// <param name="F">Degré F</param>
        /// <param name="expected">Résultat attendu</param>
        /// <remarks>T02</remarks>
        [Theory]
        [InlineData(32, 0)]
        [InlineData(-40, -40)]
        [InlineData(-4, -20)]
        [InlineData(0, -17.8)]
        [InlineData(98.6, 37)]
        [InlineData(212, 100)]
        public void FahrenheitInCelsius_AlwaysReturnGoodValue(double F, double expected)
        {
            TemperatureViewModel model = new TemperatureViewModel();

            double actual = model.FahrenheitInCelsius(F);

            Assert.Equal(expected, actual);

        }

        /// <summary>
        /// Lorsqu'exécuté GetTempCommand devrait lancer une NullException
        /// </summary>
        /// <remarks>T03</remarks>
        [Fact]
        public void GetTempCommand_ExecuteIfNullService_ShouldThrowNullException()
        {
            // Arrange
            TemperatureViewModel temp = new TemperatureViewModel();

            // Act       


            // Assert
            Assert.Throws<Exception>(() => temp.GetTempCommand.Execute(""));

            /// TODO : git commit -a -m "T03 GetTempCommand_ExecuteIfNullService_ShouldThrowNullException : Done"
        }

        /// <summary>
        /// La méthode CanGetTemp devrait retourner faux si le service est null
        /// </summary>
        /// <remarks>T04</remarks>
        [Fact]
        public void CanGetTemp_WhenServiceIsNull_ReturnsFalse()
        {
            TemperatureViewModel temp = new TemperatureViewModel();
            bool expected = false;

            Assert.Equal(temp.CanGetTemp(""), expected);
            
        }

        /// <summary>
        /// La méthode CanGetTemp devrait retourner vrai si le service est instancié
        /// </summary>
        /// <remarks>T05</remarks>
        [Fact]
        public void CanGetTemp_WhenServiceIsSet_ReturnsTrue()
        {

            TemperatureViewModel temp = new TemperatureViewModel();

            temp.SetTemperatureService(new tempClass());

            var expected = true;
            var actual = temp.CanGetTemp("");

            Assert.Equal(expected, actual);

        }

        /// <summary>
        /// TemperatureService ne devrait plus être null lorsque SetTemperatureService
        /// </summary>
        /// <remarks>T06</remarks>
        [Fact]
        public void SetTemperatureService_WhenExecuted_TemperatureServiceIsNotNull()
        {
            TemperatureViewModel temp = new TemperatureViewModel();

            temp.SetTemperatureService(new tempClass());

            Assert.NotNull(temp.TemperatureService);

            /// TODO : git commit -a -m "T06 SetTemperatureService_WhenExecuted_TemperatureServiceIsNotNull : Done"
        }

        /// <summary>
        /// CurrentTemp devrait avoir une valeur lorsque GetTempCommand est exécutée
        /// </summary>
        /// <remarks>T07</remarks>
        [Fact]
        public void GetTempCommand_HaveCurrentTempWhenExecuted_ShouldPass()
        {

            TemperatureViewModel temp = new TemperatureViewModel();

            temp.CurrentTemp = new TemperatureModel();

            temp.SetTemperatureService(new tempClass());

            temp.GetTempCommand.Execute("");

            Assert.NotNull(temp.CurrentTemp);

            

            /// TODO : git commit -a -m "T07 GetTempCommand_HaveCurrentTempWhenExecuted_ShouldPass : Done"
        }

        
        /// <summary>
        /// Ne touchez pas à ça, c'est seulement pour respecter les standards
        /// de test qui veulent que la classe de tests implémente IDisposable
        /// Mais ça peut être utilisé, par exemple, si on a une connexion ouverte, il
        /// faut s'assurer qu'elle sera fermée lorsque l'objet sera détruit
        /// </summary>
        public void Dispose()
        {
            // Nothing to here, just for Testing standards
        }

        class tempClass : ITemperatureService
        {
            public Task<TemperatureModel> GetTempAsync()
            {
                throw new NotImplementedException();
            }
        }
    }
}
