using System.Collections.Immutable;
using UnitConverter.Models.Enumeration;

namespace UnitConverter.Services
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
            double result = celsiusValue + 273.15;
            return Math.Round(result, 2, MidpointRounding.ToEven);
        }

        private double ConvertToFahrenheit(double celsiusValue)
        {
            double result = celsiusValue * 1.8 + 32;          
            return Math.Round(result);

        }

    }
}
