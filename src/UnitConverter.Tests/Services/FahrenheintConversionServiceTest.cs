using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Models.Enumeration;
using UnitConverter.Services;

namespace UnitConverter.src.UnitConverter.Tests.Services
{
    [TestClass]
    class FahrenheintConversionServiceTest
    {

        private readonly FahrenheintConversionService _service = FahrenheintConversionService.Instance;

        [TestMethod]
        [DataRow(TemperatureUnits.Fahrenheit, TemperatureUnits.Celsius, true)]
        [DataRow(TemperatureUnits.Fahrenheit, TemperatureUnits.Kelvin, true)]
        [DataRow(TemperatureUnits.Fahrenheit, TemperatureUnits.Fahrenheit, false)]
        [DataRow(TemperatureUnits.Celsius, TemperatureUnits.Kelvin, false)]
        [DataRow(TemperatureUnits.Celsius, TemperatureUnits.Fahrenheit, false)]
        [DataRow(TemperatureUnits.Celsius, TemperatureUnits.Celsius, false)]
        [DataRow(TemperatureUnits.Kelvin, TemperatureUnits.Fahrenheit, false)]
        [DataRow(TemperatureUnits.Kelvin, TemperatureUnits.Celsius, false)]
        [DataRow(TemperatureUnits.Kelvin, TemperatureUnits.Kelvin, false)]
        public void CanConvert_ShouldReturnTrue(TemperatureUnits from, TemperatureUnits to, bool expectedResult)
        {
            bool actualResult = _service.CanConvert(from, to);

            Assert.AreEqual(expectedResult, actualResult, $"Failed for conversion from {from} to {to}");
        }

    }
}
