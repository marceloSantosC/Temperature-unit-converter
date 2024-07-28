using UnitConverter.src.UnitConverter.Models.Enumeration;

namespace UnitConverter.src.UnitConverter.Services
{
     interface ITemperatureConversionService
    {

        public double Convert(TemperatureUnits to, double value);

        public bool CanConvert(TemperatureUnits from, TemperatureUnits to);

    }
}
