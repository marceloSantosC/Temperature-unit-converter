using UnitConverter.Models.Enumeration;

namespace UnitConverter.Services
{
     public interface ITemperatureConversionService
    {

        public double Convert(TemperatureUnits to, double value);

        public bool CanConvert(TemperatureUnits from, TemperatureUnits to);

    }
}
