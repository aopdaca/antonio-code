using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MySoapService
{
    [DataContract]
    public class Temperature
    {
        [DataMember]
        public double Value { get; set; }
        [DataMember]
        public TemperatureUnit Unit { get; set; }
    }
}