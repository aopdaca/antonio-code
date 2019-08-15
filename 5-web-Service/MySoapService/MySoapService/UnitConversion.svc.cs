using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MySoapService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UnitConversion" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UnitConversion.svc or UnitConversion.svc.cs at the Solution Explorer and start debugging.
    public class UnitConversion : IUnitConversion
    {
        public Temperature ConvertTemp(Temperature temp)
        {
            switch (temp.Unit)
            {
                case TemperatureUnit.Celsius:
                    return new Temperature
                    {
                        Unit = TemperatureUnit.Fahrenheit,
                        Value = temp.Value * 9 / 5 + 32
                    };
                case TemperatureUnit.Fahrenheit:
                    return new Temperature
                    {
                        Unit = TemperatureUnit.Celsius,
                        Value = temp.Value * 9 / 5 + 32
                    };

                default:
                    return null;
            }
        }

        public double FeetToMeeters(double feet)
        {
            return feet/3.28;
        }
    }
}
