using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GarageApplication
{
    public class Menu
    {
        public string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SavedGarages\\";
        public Menu()
        {
            Directory.CreateDirectory(path);
        }
        // StartMenu är första menyn där man bara väljer ifall man vill starta ett nytt garage eller ladda ett som man sparat tidigare
        public void StartMenu()
        {
            bool quitStartMenu = false;
            Console.WriteLine("Welcome to garage simulator!\n" +
                "1. Create new garage\n" +
                "2. Load saved garage\n" +
                "3. Exit application\n");
            do
            {
                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("How many vehicles can be parked in the garage?\n");
                        int garageSpace = int.Parse(Console.ReadLine());
                        Garage<Vehicle> newGarage = new Garage<Vehicle>(garageSpace);
                        GarageMenu(newGarage);
                        quitStartMenu = true;
                        break;
                    case 2:
                        Console.WriteLine("Previously saved garages:\n");
                        SaveLoadJson.FindAllSavedFiles(path);
                        Console.WriteLine("Which one do you want to load?\n");
                        string userInput = Console.ReadLine();
                        var garage = SaveLoadJson.LoadJSON(path, userInput);
                        GarageMenu(garage);
                        quitStartMenu = true;
                        break;
                    case 3:
                        quitStartMenu = true;
                        break;
                }
            } while (!quitStartMenu);
        }
        // GarageMenu är menyn som har med garagets funktioner att göra och körs efter StartMenu
        public void GarageMenu(Garage<Vehicle> garage)
        {
            Garage<Vehicle> thisgarage = garage;
            bool quitApplication = false;
            do
            {
                Console.WriteLine("You have entered your garage, what now?\n" +
                    "1. Print all vehicles in garage\n" +              
                    "2. Print all types of vehicles in garage\n" + 
                    "3. Search for a vehicle\n" + 
                    "4. Add a vehicle to garage\n" +
                    "5. (populate) Remove a vehicle from garage\n" +
                    "6. Save garage\n" +
                    "7. Exit application\n");
                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        thisgarage.ListVehicle();
                        continue;
                    case 2:
                        thisgarage.CountVehicleTypes();
                        continue;
                    case 3:
                        // fixa sökfunktionen
                        continue;
                    case 4:
                        // fixa funktion för att skapa nya objekt av fordon och lägga til
                        continue;
                    case 5:
                        // kom på hur vi ska ta bort fordon
                        continue;
                    case 6:
                        Console.WriteLine("Vad vill du döpa garaget till?\n");
                        string garageName = Console.ReadLine();
                        SaveLoadJson.SerializeJSON(path, garageName, thisgarage);
                        break;
                    case 7:
                        quitApplication = true;
                        break;
                }
            } while (!quitApplication);
        }
        public void SearchMenu()
        {
            Console.WriteLine("Find a vehicle in the garage by adding a parameter.\n" +
                         "1. To find with a registration number.\n" +
                         "2. To find all with colour.\n" +
                         "3. To find all with a specified number of wheels.\n" +
                         "4. To find all by manufacturer.\n" +
                         "5. To find all by vehicle type.\n" +
                         "0. Exit the finding!\n");
        }
        public Vehicle CreateVehicleMenu()
        {
            Vehicle returnVehicle = null;
            return returnVehicle;
        }
    }
}
