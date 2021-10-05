using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    public class Vehicle
    {
        public string RegistrationNumber { get; protected set; }
        public string Color { get; protected set; }
        public int WheelsAmount { get; protected set; }
        public override string ToString()   
        {
            return string.Format($"Vehicle type: { GetType().Name }\n" +       
                $"Registration number: { RegistrationNumber }\n" +
                $"Color: { Color }\n" +
                $"Number of wheels: { WheelsAmount }\n");
        }
    }
}
