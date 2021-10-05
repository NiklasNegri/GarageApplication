using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    public class Car : Vehicle
    {
        public string CarManufacturer { get; private set; }
        public bool IsRallyCar { get; private set; }
        public Car(string _registrationNumber, string _color, int _wheelsAmount, bool _isRallyCar, string _carManufacturer)
        {
            RegistrationNumber = _registrationNumber;
            Color = _color;
            WheelsAmount = _wheelsAmount;
            IsRallyCar = _isRallyCar;
            CarManufacturer = _carManufacturer;
        }
        public override string ToString()
        {
            return base.ToString() +
                string.Format($"Is rally car: { IsRallyCar }\n" +
                $"Car manufacturer: { CarManufacturer }");
        }
    }
}
