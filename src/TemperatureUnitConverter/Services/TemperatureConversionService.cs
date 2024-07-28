using System.Collections.Immutable;
using UnitConverter.Models.Enumeration;
using UnitConverter.Models.Exceptions;

namespace UnitConverter.Services
{
    public class TemperatureConversionService(ImmutableList<ITemperatureConversionService> _conversionServices)
    {
        public double ConvertTemperature(TemperatureUnits from, TemperatureUnits to, double temperature)
        {
            var conversionService = _conversionServices.Find(service => service.CanConvert(from, to)) ??
                                    throw new InvalidConversionException(from, to);
            return conversionService.Convert(to, temperature);
        }

    }
}
