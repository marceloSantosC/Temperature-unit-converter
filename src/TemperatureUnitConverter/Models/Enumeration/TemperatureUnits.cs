using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Models.Enumeration
{

    public enum TemperatureUnits
    {
        [Description("Graus Celsius")]
        Celsius = 1,

        [Description("Fahrenheit")]
        Fahrenheit = 2,

        [Description("Kelvin")]
        Kelvin = 3
    }

}
