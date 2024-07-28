using System.Collections.Immutable;
using UnitConverter.src.UnitConverter.Models.Enumeration;

namespace UnitConverter.src.UnitConverter.Services
{
    class KelvinConversionService : ITemperatureConversionService
    {


        static readonly ImmutableList<TemperatureConversions> SupportedConversions =
        [
             TemperatureConversions.KelvinToFahrenheit,
             TemperatureConversions.KelvinToCelsius
        ];

        private KelvinConversionService() { }

        private static readonly Lazy<KelvinConversionService> _instance = new Lazy<KelvinConversionService>(() => new KelvinConversionService());

        public static KelvinConversionService Instance => _instance.Value;

        public bool CanConvert(TemperatureUnits from, TemperatureUnits to)
        {
            return SupportedConversions.Exists(conversion => conversion.CanConvert(from, to));
        }

        public double Convert(TemperatureUnits to, double value)
        {
            if (TemperatureUnits.Celsius.Equals(to))
            {
                return ConvertToCelsius(value);
            }

           
            return ConvertToFahrenheit(value);

        }

        private static double ConvertToCelsius(double kelvinValue)
        {
            return kelvinValue - 273.15;
        }

        private static double ConvertToFahrenheit(double kelvinValue)
        {
            return (kelvinValue - 273) * 1.8 + 32;
        }

    }
}
