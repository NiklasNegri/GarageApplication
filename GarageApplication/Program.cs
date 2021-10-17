using System;
using System.IO;

namespace GarageApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create object of Garage class
            //Garage<Vehicle> newGarage = new Garage<Vehicle>(15);

            // Populate list with every type of object
            //PopulateGarage(newGarage);
            //SaveLoadJson.SerializeJSON((Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SavedGarages\\"), "testGarage", newGarage);
            //newGarage.ListVehicle();
            // TEST COUNT VEHICLE TYPES METHOD
            //newGarage.CountVehicleTypes();

            // TEST SEARCH METHOD
            //Console.WriteLine("Enter search phrase!");
            //string searchPhrase = Console.ReadLine();
            //newGarage.SearchVehicle(searchPhrase);

            Menu menu = new Menu();

            menu.StartMenu();

            Console.ReadKey();
        }
        public static void PopulateGarage(Garage<Vehicle> garage)
        {
            garage.AddVehicle(new Bicycle("Monark", "BIKEREG", "Green", 2, 6, false));
            garage.AddVehicle(new Bus("Volvo", "ABC123", "Blue", 8, false, 16));
            garage.AddVehicle(new Car("Mercedez", "DEF456", "Red", 4, 350, true));
            garage.AddVehicle(new Truck("Nissan", "GHI789", "Blue", 4, true, true));
            garage.AddVehicle(new Motorcycle("Triumph", "JKL000", "Blue", 2, 1500, false));
        }
    }
}
