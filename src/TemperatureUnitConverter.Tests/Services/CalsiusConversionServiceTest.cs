using UnitConverter.Services;
using Moq;
using UnitConverter.Models.Enumeration;
using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConverter.Models.Exceptions;

namespace UnitConverter.Tests.Services
{

    [TestClass]
    public class CalsiusConversionServiceTest
    {

        private readonly CelsiusConversionService _service = CelsiusConversionService.Instance;

        [TestMethod]
        [DataRow(TemperatureUnits.Celsius, TemperatureUnits.Kelvin, true)]
        [DataRow(TemperatureUnits.Celsius, TemperatureUnits.Fahrenheit, true)]
        [DataRow(TemperatureUnits.Celsius, TemperatureUnits.Celsius, false)]
        [DataRow(TemperatureUnits.Fahrenheit, TemperatureUnits.Celsius, false)]
        [DataRow(TemperatureUnits.Fahrenheit, TemperatureUnits.Kelvin, false)]
        [DataRow(TemperatureUnits.Fahrenheit, TemperatureUnits.Fahrenheit, false)]
        [DataRow(TemperatureUnits.Kelvin, TemperatureUnits.Fahrenheit, false)]
        [DataRow(TemperatureUnits.Kelvin, TemperatureUnits.Celsius, false)]
        [DataRow(TemperatureUnits.Kelvin, TemperatureUnits.Kelvin, false)]
        public void CanConvert_ShouldReturnTrue(TemperatureUnits from, TemperatureUnits to, bool expectedResult)
        {
            bool actualResult = _service.CanConvert(from, to);

            Assert.AreEqual(expectedResult, actualResult, $"Failed for conversion from {from} to {to}");
        }

        [TestMethod]
        [DataRow(TemperatureUnits.Kelvin, 0D, 273.15D)]
        [DataRow(TemperatureUnits.Fahrenheit, 0D, 32)]
        public void Convert_ShouldReturnExpectedValue(TemperatureUnits convertTo, double value, double expectedResult)
        {
            double actualResult = _service.Convert(convertTo, value);

            Assert.AreEqual(expectedResult, actualResult, $"Invalid {convertTo} conversion result for value {value} , expected {expectedResult} but was {actualResult}");
        }

    }
}
