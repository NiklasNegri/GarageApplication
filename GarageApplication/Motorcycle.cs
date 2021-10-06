using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    public class Motorcycle : Vehicle
    {
        public int CubicCapacity { get; private set; }
        public bool HasApeHangers { get; private set; }
        public Motorcycle(string _manufacturer, string _registrationNumber, string _color, int _wheelsAmount, int _cubicCapacity, bool _hasApeHangers)
        {
            Manufacturer = _manufacturer;
            RegistrationNumber = _registrationNumber;
            Color = _color;
            WheelsAmount = _wheelsAmount;
            CubicCapacity = _cubicCapacity;
            HasApeHangers = _hasApeHangers;
        }
        public override string ToString()
        {
            return base.ToString() +
                string.Format($"Engines cubic capacity: { CubicCapacity }\n" +
                $"Has ape hangers: { HasApeHangers }\n");
        }
    }
}
