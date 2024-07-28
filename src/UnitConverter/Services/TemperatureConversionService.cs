using System.Collections.Immutable;
using UnitConverter.src.UnitConverter.Models.Enumeration;
using UnitConverter.src.UnitConverter.Models.Exceptions;

namespace UnitConverter.src.UnitConverter.Services
{
    class TemperatureConversionService
    {

        private readonly ImmutableList<ITemperatureConversionService> conversionServices;

        public TemperatureConversionService(ImmutableList<ITemperatureConversionService> conversionServices) {
            this.conversionServices = conversionServices;
        }


        public double ConvertTemperature(TemperatureUnits from, TemperatureUnits to, double temperature)
        {
            var conversionService = conversionServices.Find(service => service.CanConvert(from, to)) ??
                                throw new InvalidConversionException(from, to);
            return conversionService.Convert(to, temperature);
        }

    }
}
