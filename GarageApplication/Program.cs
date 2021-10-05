using System;

namespace GarageApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // POPULATE LIST WITH OBJECTS
            Garage<Vehicle> newGarage = new Garage<Vehicle>(15);
            newGarage.AddVehicle(new Bus("ABC123", "Blue", 4, false, 16));
            newGarage.AddVehicle(new Car("DEF456", "Red", 4, false, "Volvo"));
            newGarage.AddVehicle(new Truck("ABC123", "Blue", 4, false, true));
            newGarage.AddVehicle(new Motorcycle("ABC123", "Blue", 2, 1500, false));

            // TEST COUNT VEHICLE TYPES METHOD
            newGarage.CountVehicleTypes();

            // TEST SEARCH METHOD
            Console.WriteLine("Enter search phrase!");
            string searchPhrase = Console.ReadLine();
            newGarage.SearchVehicle(searchPhrase);

            //newGarage.RemoveVehicle(newGarage.SearchVehicle(searchPhrase));

            Console.ReadKey();
        }
    }
}
