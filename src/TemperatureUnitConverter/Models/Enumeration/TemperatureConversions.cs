using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Models.Enumeration
{
    public class TemperatureConversions
    {

        public static readonly TemperatureConversions KelvinToCelsius = new(TemperatureUnits.Kelvin, TemperatureUnits.Celsius);
        public static readonly TemperatureConversions KelvinToFahrenheit = new(TemperatureUnits.Kelvin, TemperatureUnits.Fahrenheit);

        public static readonly TemperatureConversions CelsiusToKelvin = new(TemperatureUnits.Celsius, TemperatureUnits.Kelvin);
        public static readonly TemperatureConversions CelsiusToFahrenheit = new(TemperatureUnits.Celsius, TemperatureUnits.Fahrenheit);

        public static readonly TemperatureConversions FahrenheitToCelsius = new(TemperatureUnits.Fahrenheit, TemperatureUnits.Celsius);
        public static readonly TemperatureConversions FahrenheitToKelvin = new(TemperatureUnits.Fahrenheit, TemperatureUnits.Kelvin);

        public TemperatureUnits From { get; }
        public TemperatureUnits To { get; }

        private TemperatureConversions(TemperatureUnits firstUnit, TemperatureUnits secondUnit)
        {
            From = firstUnit;
            To = secondUnit;   
        }


        public bool CanConvert(TemperatureUnits from, TemperatureUnits to)
        {
            return From.Equals(from) && To.Equals(to);
        }

    }
}
