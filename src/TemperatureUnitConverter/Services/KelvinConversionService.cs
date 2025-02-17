﻿using System.Collections.Immutable;
using UnitConverter.Models.Enumeration;

namespace UnitConverter.Services
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
            double result = kelvinValue - 273.15;
            return Math.Round(result, 2, MidpointRounding.ToEven);
        }

        private static double ConvertToFahrenheit(double kelvinValue)
        {
            double result = (kelvinValue - 273.15) * 1.8 + 32;
            return Math.Round(result, 2, MidpointRounding.ToEven); 
        }

    }
}
