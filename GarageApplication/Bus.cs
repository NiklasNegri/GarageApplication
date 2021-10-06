using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    public class Bus : Vehicle
    {
        public bool IsSchoolBus { get; private set; }
        public int MaxPassangerCapacity { get; private set; }
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
