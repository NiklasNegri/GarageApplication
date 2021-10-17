using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    public class Truck : Vehicle 
    {
        public bool HasAllWheelDrive { get; set; }
        public bool IsDieselEngine { get; set; }
        public Truck(string _manufacturer, string _registrationNumber, string _color, int _wheelsAmount, bool _hasAllWheelDrive, bool _isDieselEngine)
        {
            Manufacturer = _manufacturer;
            RegistrationNumber = _registrationNumber;
            Color = _color;
            WheelsAmount = _wheelsAmount;
            HasAllWheelDrive = _hasAllWheelDrive;
            IsDieselEngine = _isDieselEngine;
        }
        public override string ToString()
        {
            return base.ToString() +
                string.Format($"Has all wheel drive: { HasAllWheelDrive }\n" +
                $"Diesel engine: { IsDieselEngine }\n");
        }
    }
}
