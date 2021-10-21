using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GarageApplication
{
    /// <summary>
    /// Class Garage contains the list with Vehicles which is the main function of the program,
    /// as well as containing methods for adding, removing, searching and listing the vehicles in the garage.
    /// Every method and property is appropriately named and describing their function and wont be commented further.
    /// </summary>
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public List<T> ParkedVehicles { get; set; }
        public int Capacity { get; set; }
        public Garage(int capacity)
        {
            Capacity = capacity;
            ParkedVehicles = new List<T>(Capacity);
        }
        public Garage(List<T> vehicles)
        {
            ParkedVehicles = vehicles;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ParkedVehicles.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ParkedVehicles.GetEnumerator();
        }
        public void AddVehicle(T item)
        {
            ParkedVehicles.Add(item);
        }
        public void ListVehicle()
        {
            if (ParkedVehicles.Count == 0)
            {
                Console.WriteLine("There are no parked vehicles in the garage!\n");
            }
            else
            {
                int count = 1;
                foreach (T item in ParkedVehicles)
                {
                    Console.WriteLine($"{ count }. \n{ item }\n");
                    count++;
                }
            }          
        }
        public void CountVehicleTypes()
        {
            if (ParkedVehicles.Count == 0)
            {
                Console.WriteLine("There are no parked vehicles in the garage!\n");
            }
            else
            {
                int bicycleCount = 0, busCount = 0, carCount = 0, motorcycleCount = 0, truckCount = 0;
                foreach (var item in ParkedVehicles)
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
                Console.WriteLine($"\nAmount of bicycles in garage: { bicycleCount }\n" +
                $"Amount of buses in garage: { busCount }\n" +
                $"Amount of cars in garage: { carCount }\n" +
                $"Amount of motorcycles in garage: { motorcycleCount }\n" +
                $"Amount of trucks in garage: { truckCount }\n" +
                $"Total amount of vehicles in garage: { bicycleCount + busCount + carCount + motorcycleCount + truckCount}\n");
            }                      
        }
        public Vehicle SearchVehicle(string searchString)
        {
            Vehicle returnVehicle = null;
            if (ParkedVehicles.Count == 0)
            {
                Console.WriteLine("There are no parked vehicles in the garage!\n");
            }
            else
            {
                string[] keywords = searchString.Split(' ');
                foreach (var key in keywords)
                {
                    foreach (T item in ParkedVehicles)
                    {
                        if (item.RegistrationNumber.ToUpper() == key.ToUpper())
                        {
                            Console.WriteLine($"\nVehicle found!\n{ item }");
                            returnVehicle = item;
                        }
                        else if (item.Color.ToUpper() == key.ToUpper())
                        {
                            Console.WriteLine($"\nVehicle found!\n{ item }");
                            returnVehicle = item;
                        }
                        else if (item.GetType().Name.ToUpper() == key.ToUpper())
                        {
                            Console.WriteLine($"\nVehicle found!\n{ item }");
                            returnVehicle = item;
                        }
                        else if (Convert.ToString(item.WheelsAmount) == key)
                        {
                            Console.WriteLine($"\nVehicle found!\n{ item }");
                            returnVehicle = item;
                        }
                        else if (Convert.ToString(item.Manufacturer) == key)
                        {
                            Console.WriteLine($"\nVehicle found!\n{ item }");
                            returnVehicle = item;
                        }
                    }
                }              
            }
            if (returnVehicle == null)
            {
                Console.WriteLine($"\nNo vehicles with chosen search { searchString } was found!\n");
            }
            return returnVehicle;
        }
        public void RemoveVehicle(int listIndex)
        {
            if (ParkedVehicles.Count == 0)
            {
                Console.WriteLine("There are no parked vehicles in the garage!\n");
            }
            else
            {
                Vehicle item = ParkedVehicles[listIndex];
                ParkedVehicles.RemoveAt(listIndex);
                Console.WriteLine($"{ item.GetType().Name } with reg nr { item.RegistrationNumber } removed!\n");
            }      
        }
        UserInputHelper userInputHelper = new UserInputHelper();
        public Bicycle MakeBicycle()
        {
            Console.WriteLine("Manufacturer: ");
            string vehicleManufacturer = userInputHelper.ParseStringInput();
            Console.WriteLine("Registration Number: ");
            string vehicleRegNr = Console.ReadLine();
            Console.WriteLine("Color: ");
            string vehicleColor = userInputHelper.ParseStringInput();
            Console.WriteLine("Amount of Wheels: ");
            int vehicleWheels = userInputHelper.ParseIntInput();
            Console.WriteLine("Amount of Gears: ");
            int vehicleGears = userInputHelper.ParseIntInput();
            Console.WriteLine("Is it a BMX (Yes/No): ");
            string vehicleBMX = userInputHelper.ParseStringInput().ToLower();
            bool vehicleIsBMX;
            if (vehicleBMX == "yes")
            {
                vehicleIsBMX = true;
            }
            else
            {
                vehicleIsBMX = false;
            }
            Bicycle item = new Bicycle(vehicleManufacturer, vehicleRegNr, vehicleColor, vehicleWheels,
                    vehicleGears, vehicleIsBMX);
            return item;
        }
        public Bus MakeBus()
        {
            Console.WriteLine("Manufacturer: ");
            string vehicleManufacturer = userInputHelper.ParseStringInput();
            Console.WriteLine("Registration Number: ");
            string vehicleRegNr = Console.ReadLine();
            Console.WriteLine("Color: ");
            string vehicleColor = userInputHelper.ParseStringInput();
            Console.WriteLine("Amount of Wheels: ");
            int vehicleWheels = userInputHelper.ParseIntInput();
            Console.WriteLine("Maximum Passanger Capacity: ");
            int vehicleMaxPasCap = userInputHelper.ParseIntInput();
            Console.WriteLine("Is it a School Bus? (Yes/No): ");
            string vehicleSchool = userInputHelper.ParseStringInput().ToLower();
            bool vehicleIsSchool;
            if (vehicleSchool == "yes")
            {
                vehicleIsSchool = true;
            }
            else
            {
                vehicleIsSchool = false;
            }
            Bus item = new Bus(vehicleManufacturer, vehicleRegNr, vehicleColor, vehicleWheels,
                    vehicleIsSchool, vehicleMaxPasCap);
            return item;
        }
        public Car MakeCar()
        {
            Console.WriteLine("Manufacturer: ");
            string vehicleManufacturer = userInputHelper.ParseStringInput();
            Console.WriteLine("Registration Number: ");
            string vehicleRegNr = Console.ReadLine();
            Console.WriteLine("Color: ");
            string vehicleColor = userInputHelper.ParseStringInput();
            Console.WriteLine("Amount of Wheels: ");
            int vehicleWheels = userInputHelper.ParseIntInput();
            Console.WriteLine("Amount of Horsepower: ");
            int vehicleHP = userInputHelper.ParseIntInput();
            Console.WriteLine("Is it a Convertable (Yes/No): ");
            string vehicleConv = userInputHelper.ParseStringInput().ToLower();
            bool vehicleIsConv;
            if (vehicleConv == "yes")
            {
                vehicleIsConv = true;
            }
            else
            {
                vehicleIsConv = false;
            }
            Car item = new Car(vehicleManufacturer, vehicleRegNr, vehicleColor, vehicleWheels,
                    vehicleHP, vehicleIsConv);
            return item;
        }
        public Truck MakeTruck()
        {
            Console.WriteLine("Manufacturer: ");
            string vehicleManufacturer = userInputHelper.ParseStringInput();
            Console.WriteLine("Registration Number: ");
            string vehicleRegNr = Console.ReadLine();
            Console.WriteLine("Color: ");
            string vehicleColor = userInputHelper.ParseStringInput();
            Console.WriteLine("Amount of Wheels: ");
            int vehicleWheels = userInputHelper.ParseIntInput();
            Console.WriteLine("Is it an All Wheel Drive? (Yes/No): ");
            string vehicleAllWheelDrive = userInputHelper.ParseStringInput().ToLower();
            bool vehicleIsAllWheelDrive;
            if (vehicleAllWheelDrive == "yes")
            {
                vehicleIsAllWheelDrive = true;
            }
            else
            {
                vehicleIsAllWheelDrive = false;
            }
            Console.WriteLine("Does it run on Diesel? (Yes/No): ");
            string vehicleDiesel = userInputHelper.ParseStringInput().ToLower();
            bool vehicleIsDiesel;
            if (vehicleDiesel == "yes")
            {
                vehicleIsDiesel = true;
            }
            else
            {
                vehicleIsDiesel = false;
            }
            Truck item = new Truck(vehicleManufacturer, vehicleRegNr, vehicleColor, vehicleWheels,
                    vehicleIsAllWheelDrive, vehicleIsDiesel);
            return item;
        }
        public Motorcycle MakeMotorcycle()
        {
            Console.WriteLine("Manufacturer: ");
            string vehicleManufacturer = userInputHelper.ParseStringInput();
            Console.WriteLine("Registration Number: ");
            string vehicleRegNr = Console.ReadLine();
            Console.WriteLine("Color: ");
            string vehicleColor = userInputHelper.ParseStringInput();
            Console.WriteLine("Amount of Wheels: ");
            int vehicleWheels = userInputHelper.ParseIntInput();
            Console.WriteLine("Cubic Capacity: ");
            int vehicleCC = userInputHelper.ParseIntInput();
            Console.WriteLine("Does it have Ape Hangers (Yes/No): ");
            string vehicleApe = userInputHelper.ParseStringInput().ToLower();
            bool vehicleIsApe;
            if (vehicleApe == "yes")
            {
                vehicleIsApe = true;
            }
            else
            {
                vehicleIsApe = false;
            }
            Motorcycle item = new Motorcycle(vehicleManufacturer, vehicleRegNr, vehicleColor, vehicleWheels,
                    vehicleCC, vehicleIsApe);
            return item;
        }
    }
}
