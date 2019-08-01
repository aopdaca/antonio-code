using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Serialization
{
    class Person
    {
        [XmlAttribute] //make Id serialize as an XML attribute of the person element
        //instead as elemnt of its own
        public int Id { get; set; }
        public string FirstName { get; set; }

        [XmlElement(ElementName = "FamilyName")]
        public string LastName { get; set; }
        public Address Address { get; set; }

        [XmlIgnore]
        [JsonIgnore] //hidden from serializer
        public int DataToNotSerialize { get; set; }

        
    }
}
