using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    /// <summary>
    /// Class Bicycle inherits from class Vehicle and contains 2 public propertys with private setters.
    /// </summary>
    public class Bicycle : Vehicle
    {
        public int AmountGears { get; private set; }
        public bool IsBMXbike { get; private set; }
        /// <summary>
        /// Constructor that takes 5 arguments to assign value to class and inherited propertys.
        /// </summary>
        public Bicycle(string _manufacturer, string _registrationNumber, string _color, int _wheelsAmount, int _amountGears, bool _isBMXbike)
        {
            Manufacturer = _manufacturer;
            RegistrationNumber = _registrationNumber;
            Color = _color;
            WheelsAmount = _wheelsAmount;
            AmountGears = _amountGears;
            IsBMXbike = _isBMXbike;
        }
        public override string ToString()
        {
            return base.ToString() +
                string.Format($"Amount of gears: { AmountGears }\n" +
                $"Is a BMX bike: { IsBMXbike }\n");
        }
    }
}
