using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    public interface IEnumerable<T>
    {
        public void ListVehicle();
    }
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public List<Vehicle> parkedVehicles;
        public Garage(int maxVehicleCapacity)
        {
            parkedVehicles = new List<Vehicle>(maxVehicleCapacity);
        }
        public void AddVehicle(T item)
        {
            parkedVehicles.Add(item);
        }
        public void ListVehicle()
        {
            foreach (T item in parkedVehicles)
            {
                Console.WriteLine($"{ item.GetType().Name }, { item.RegistrationNumber }");
                Console.WriteLine(item);
            }
        }
        public void CountVehicleTypes()
        {
            int bicycleCount = 0, busCount = 0, carCount = 0, motorcycleCount = 0, truckCount = 0;
            foreach (var item in parkedVehicles)
            {
                if (item.GetType().Name == "Bicycle")
                {
                    bicycleCount++;
                }
                else if (item.GetType().Name == "Bus")
                {
                    busCount++;
                }
                else if (item.GetType().Name == "Car")
                {
                    carCount++;
                }
                else if (item.GetType().Name == "Motorcycle")
                {
                    motorcycleCount++;
                }
                else if (item.GetType().Name == "Truck")
                {
                    truckCount++;
                }
            }
            Console.WriteLine($"Amount of bicycles in garage: { bicycleCount }\n" +
                $"Amount of buses in garage: { busCount }\n" +
                $"Amount of cars in garage: { carCount }\n" +
                $"Amount of motorcycles in garage: { motorcycleCount }\n" +
                $"Amount of trucks in garage: { truckCount }\n" +
                $"Total amount of vehicles in garage: { bicycleCount + busCount + carCount + motorcycleCount + truckCount}");            
        }
        /// <summary>
        /// SearchVehicle finds first object with a property that matches the search phrase and returns it.
        /// </summary>
        public Vehicle SearchVehicle(string searchString)
        {
            Vehicle returnVehicle = null;
            foreach (T item in parkedVehicles)
            {
                if (item.RegistrationNumber.ToUpper() == searchString.ToUpper())
                {
                    Console.WriteLine($"Vehicle found!\n { item }\n");
                    returnVehicle = item;
                    break;
                }
                else if (item.Color.ToUpper() == searchString.ToUpper())
                {
                    Console.WriteLine($"Vehicle found!\n { item }\n");
                    returnVehicle = item;
                    break;
                }
                else if (item.GetType().Name.ToUpper() == searchString.ToUpper())
                {
                    Console.WriteLine($"Vehicle found!\n { item }\n");
                    returnVehicle = item;
                    break;
                }
                else if (Convert.ToString(item.WheelsAmount) == searchString)             
                {
                    Console.WriteLine($"Vehicle found!\n { item }\n");
                    returnVehicle = item;
                    break;
                }
            }
            return returnVehicle;
        }
        public void RemoveVehicle(T item)
        {
            parkedVehicles.Remove(item);
            Console.WriteLine($"{ item.GetType().Name } with reg nr { item.RegistrationNumber } removed!\n");
        }
    }
}
