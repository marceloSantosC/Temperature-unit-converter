using UnitConverter.src.UnitConverter.Models.Enumeration;

namespace UnitConverter.src.UnitConverter.Models.Exceptions
{
    public class InvalidConversionException(TemperatureUnits From, TemperatureUnits To) : Exception
    {
        public TemperatureUnits From { get; } = From;

        public TemperatureUnits To { get; } = To;

    }
}