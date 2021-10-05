using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    public class Bicycle : Vehicle
    {
        public int AmountGears { get; private set; }
        public bool IsBMXbike { get; private set; }
        public Bicycle(string _registrationNumber, string _color, int _wheelsAmount, int _amountGears, bool _isBMXbike)
        {
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
                $"Is a BMX bike: { IsBMXbike }");
        }
    }
}
