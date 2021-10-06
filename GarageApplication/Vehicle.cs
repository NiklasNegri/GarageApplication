using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    /// <summary>
    /// Class Vehicle contains 4 propertys and an overriden ToString method that the other "vehicles" inherit.
    /// </summary>
    public class Vehicle
    {
        public string Color { get; protected set; }
        public string Manufacturer { get; protected set; }
        public string RegistrationNumber { get; protected set; }
        public int WheelsAmount { get; protected set; }
        public override string ToString()   
        {
            return string.Format($"Vehicle type: { GetType().Name }\n" +
                $"Color: { Color }\n" +
                $"Manufacturing company: { Manufacturer }\n" +
                $"Registration number: { RegistrationNumber }\n" +           
                $"Number of wheels: { WheelsAmount }\n");
        }
    }
}
