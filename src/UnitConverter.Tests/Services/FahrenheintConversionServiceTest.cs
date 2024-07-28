using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConverter.Models.Enumeration;
using UnitConverter.Services;

namespace UnitConverter.Tests.Services
{
    [TestClass]
    public class FahrenheintConversionServiceTest
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

        [TestMethod]
        [DataRow(TemperatureUnits.Kelvin, 0D, 255.37)]
        [DataRow(TemperatureUnits.Celsius, 0D, -17.78)]
        public void Convert_ShouldReturnExpectedValue(TemperatureUnits convertTo, double value, double expectedResult)
        {
            double actualResult = _service.Convert(convertTo, value);

            Assert.AreEqual(expectedResult, actualResult, $"Invalid {convertTo} conversion result for value {value} , expected {expectedResult} but was {actualResult}");
        }

    }
}
