using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.src.UnitConverter.Models.Enumeration;

namespace UnitConverter.src.UnitConverter.Services
{
    internal class CelsiusConversionService : ITemperatureConversionService
    {

        static readonly ImmutableList<TemperatureConversions> SupportedConversions =
        [
            TemperatureConversions.CelsiusToKelvin,
            TemperatureConversions.CelsiusToFahrenheit
        ];

        private CelsiusConversionService() { }

        private static readonly Lazy<CelsiusConversionService> _instance = new Lazy<CelsiusConversionService>(() => new CelsiusConversionService());

        public static CelsiusConversionService Instance => _instance.Value;

        public bool CanConvert(TemperatureUnits from, TemperatureUnits to)
        {
            return SupportedConversions.Exists(conversion => conversion.CanConvert(from, to));
        }

        public double Convert(TemperatureUnits to, double value)
        {
            if (TemperatureUnits.Kelvin.Equals(to))
            {
                return ConvertToKelvin(value);
            }


            return ConvertToFahrenheit(value);
        }

        private double ConvertToKelvin(double celsiusValue)
        {
            return celsiusValue + 273.15;
        }

        private double ConvertToFahrenheit(double celsiusValue)
        {
            return celsiusValue * 1.8 + 32;
        }

    }
}
