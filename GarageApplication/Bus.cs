using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    /// <summary>
    /// Class Bus inherits from class Vehicle and contains 2 public propertys with private setters.
    /// </summary>
    public class Bus : Vehicle
    {
        public bool IsSchoolBus { get; set; }
        public int MaxPassangerCapacity { get; set; }
        /// <summary>
        /// Constructor that takes 5 arguments to assign value to class and inherited propertys.
        /// </summary>
        public Bus(string _manufacturer, string _registrationNumber, string _color, int _wheelsAmount, bool _isSchoolBus, int _maxPassengerCapacity)
        {
            Manufacturer = _manufacturer;
            RegistrationNumber = _registrationNumber;
            Color = _color;
            WheelsAmount = _wheelsAmount;
            IsSchoolBus = _isSchoolBus;
            MaxPassangerCapacity = _maxPassengerCapacity;
        }
        public override string ToString()
        {
            return base.ToString() +
                string.Format($"Is school bus: { IsSchoolBus }\n" +
                $"Maximum passenger capacity: { MaxPassangerCapacity }\n");
        }
    }
}
