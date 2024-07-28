using UnitConverter.Services;
using UnitConverter.Models.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitConverter.Tests.Services
{

    [TestClass]
    public class KelvinConversionServiceTest
    {

        private readonly KelvinConversionService _service = KelvinConversionService.Instance;

        [TestMethod]
        [DataRow(TemperatureUnits.Kelvin, TemperatureUnits.Fahrenheit, true)]
        [DataRow(TemperatureUnits.Kelvin, TemperatureUnits.Celsius, true)]
        [DataRow(TemperatureUnits.Kelvin, TemperatureUnits.Kelvin, false)]
        [DataRow(TemperatureUnits.Celsius, TemperatureUnits.Kelvin, false)]
        [DataRow(TemperatureUnits.Celsius, TemperatureUnits.Fahrenheit, false)]
        [DataRow(TemperatureUnits.Celsius, TemperatureUnits.Celsius, false)]
        [DataRow(TemperatureUnits.Fahrenheit, TemperatureUnits.Celsius, false)]
        [DataRow(TemperatureUnits.Fahrenheit, TemperatureUnits.Kelvin, false)]
        [DataRow(TemperatureUnits.Fahrenheit, TemperatureUnits.Fahrenheit, false)]
        public void CanConvert_ShouldReturnTrue(TemperatureUnits from, TemperatureUnits to, bool expectedResult)
        {
            bool actualResult = _service.CanConvert(from, to);

            Assert.AreEqual(expectedResult, actualResult, $"Failed for conversion from {from} to {to}");
        }
    }
}
