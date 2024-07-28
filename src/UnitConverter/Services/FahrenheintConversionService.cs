using System.Collections.Immutable;
using UnitConverter.Models.Enumeration;

namespace UnitConverter.Services
{
    internal class FahrenheintConversionService : ITemperatureConversionService
    {

        static readonly ImmutableList<TemperatureConversions> SupportedConversions =
        [
            TemperatureConversions.FahrenheitToKelvin,
            TemperatureConversions.FahrenheitToCelsius
        ];

        private FahrenheintConversionService() { }

        private static readonly Lazy<FahrenheintConversionService> _instance = new Lazy<FahrenheintConversionService>(() => new FahrenheintConversionService());

        public static FahrenheintConversionService Instance => _instance.Value;

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


            return ConvertToCelsius(value);
        }

        private double ConvertToKelvin(double fahrenheitValue)
        {
            return ((fahrenheitValue - 32) / 1.8) + 273.15;
        }

        private double ConvertToCelsius(double fahrenheitValue)
        {
            return (fahrenheitValue - 32) / 1.8;
        }

    }
}
