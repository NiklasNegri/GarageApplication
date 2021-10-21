using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    /// <summary>
    /// Class Bicycle inherits from class Vehicle and contains 2 public propertys with private setters.
    /// </summary>
    public class Motorcycle : Vehicle
    {
        public int CubicCapacity { get; set; }
        public bool HasApeHangers { get; set; }
        /// <summary>
        /// Constructor that takes 5 arguments to assign value to class and inherited propertys.
        /// </summary>
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
