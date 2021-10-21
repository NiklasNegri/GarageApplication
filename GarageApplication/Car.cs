using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    /// <summary>
    /// Class Car inherits from class Vehicle and contains 2 public propertys with private setters.
    /// </summary>
    public class Car : Vehicle
    {
        public int Horsepower { get; set; }
        public bool IsConvertible { get; set; }
        /// <summary>
        /// Constructor that takes 5 arguments to assign value to class and inherited propertys.
        /// </summary>
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
