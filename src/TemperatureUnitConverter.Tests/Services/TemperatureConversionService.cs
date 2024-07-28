using UnitConverter.Services;
using Moq;
using UnitConverter.Models.Enumeration;
using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConverter.Models.Exceptions;

namespace UnitConverter.Tests.Services
{

    [TestClass]
    public class TemperatureConversionServiceTests
    {

        private readonly TemperatureConversionService _service;

        private readonly Mock<ITemperatureConversionService> _celsiusConversionService;
        private readonly Mock<ITemperatureConversionService> _fahrenheitConversionService;
        private readonly Mock<ITemperatureConversionService> _kelvinConversionService;

        public TemperatureConversionServiceTests()
        {
            _kelvinConversionService = new Mock<ITemperatureConversionService>();
            _celsiusConversionService = new Mock<ITemperatureConversionService>();
            _fahrenheitConversionService = new Mock<ITemperatureConversionService>();
             var conversionServices = ImmutableList.Create<ITemperatureConversionService>(
                _celsiusConversionService.Object,
                _fahrenheitConversionService.Object,
                _kelvinConversionService.Object
            );

            _service = new TemperatureConversionService(conversionServices);
        }

        [TestInitialize]
        public void Setup()
        {
            _celsiusConversionService.Setup(service => service.CanConvert(TemperatureUnits.Celsius, TemperatureUnits.Fahrenheit)).Returns(true);
            _celsiusConversionService.Setup(service => service.CanConvert(TemperatureUnits.Celsius, TemperatureUnits.Kelvin)).Returns(true);
            _celsiusConversionService.Setup(service => service.Convert(TemperatureUnits.Fahrenheit, 0)).Returns(32);

            _fahrenheitConversionService.Setup(service => service.CanConvert(It.IsAny<TemperatureUnits>(), It.IsAny<TemperatureUnits>())).Returns(false);
            _kelvinConversionService.Setup(service => service.CanConvert(It.IsAny<TemperatureUnits>(), It.IsAny<TemperatureUnits>())).Returns(false);
        }

        [TestMethod]
        public void ConvertTemperature_ShouldConvertCelsiusToFahrenheit()
        {
            double temperatureInCelsius = 0;
            double expectedTemperatureInFahrenheit = 32;

            double actualTemperatureInFahrenheit = _service.ConvertTemperature(
                TemperatureUnits.Celsius,
                TemperatureUnits.Fahrenheit,
                temperatureInCelsius
            );

            Assert.AreEqual(expectedTemperatureInFahrenheit, actualTemperatureInFahrenheit);

            _celsiusConversionService.Verify(celsius => celsius.CanConvert(TemperatureUnits.Celsius, TemperatureUnits.Fahrenheit), Times.Once);

            _celsiusConversionService.Verify(celsius => celsius.Convert(It.IsAny<TemperatureUnits>(), It.IsAny<double>()), Times.Once);
            _fahrenheitConversionService.Verify(fahrenheint => fahrenheint.Convert(It.IsAny<TemperatureUnits>(), It.IsAny<double>()), Times.Never);
            _kelvinConversionService.Verify(kelvin => kelvin.Convert(It.IsAny<TemperatureUnits>(), It.IsAny<double>()), Times.Never);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidConversionException))]
        public void ConvertTemperature_ShouldThrowInvalidConversionException_ForUnsupportedConversion()
        {
            double temperatureInCelsius = 0;

            _service.ConvertTemperature(
                TemperatureUnits.Kelvin,
                TemperatureUnits.Fahrenheit,
                temperatureInCelsius
            );

            _celsiusConversionService.Verify(celsius => celsius.CanConvert(TemperatureUnits.Celsius, TemperatureUnits.Fahrenheit), Times.Once);
            _fahrenheitConversionService.Verify(celsius => celsius.CanConvert(TemperatureUnits.Celsius, TemperatureUnits.Fahrenheit), Times.Once);
            _kelvinConversionService.Verify(celsius => celsius.CanConvert(TemperatureUnits.Celsius, TemperatureUnits.Fahrenheit), Times.Once);

            _celsiusConversionService.Verify(celsius => celsius.Convert(It.IsAny<TemperatureUnits>(), It.IsAny<double>()), Times.Never);
            _fahrenheitConversionService.Verify(fahrenheint => fahrenheint.Convert(It.IsAny<TemperatureUnits>(), It.IsAny<double>()), Times.Never);
            _kelvinConversionService.Verify(kelvin => kelvin.Convert(It.IsAny<TemperatureUnits>(), It.IsAny<double>()), Times.Never);

        }

    }
}
