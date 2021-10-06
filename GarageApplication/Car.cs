using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    public class Car : Vehicle
    {
        public int Horsepower { get; private set; }
        public bool IsConvertible { get; private set; }
        public Car(string _manufacturer, string _registrationNumber, string _color, int _wheelsAmount, int _horsepower, bool _isConvertible)
        {
            Manufacturer = _manufacturer;
            RegistrationNumber = _registrationNumber;
            Color = _color;
            WheelsAmount = _wheelsAmount;
            Horsepower = _horsepower;
            IsConvertible = _isConvertible;
        }
        public override string ToString()
        {
            return base.ToString() +
                string.Format($"{ Horsepower } horsepowers\n" +
                $"Is convertible: { IsConvertible }\n");
        }
    }
}
