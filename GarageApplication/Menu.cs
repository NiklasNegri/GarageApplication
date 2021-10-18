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
                "2. Load saved list\n" +
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
                        string input = Console.ReadLine();
                        var loadList = SaveLoadJson.LoadJSONList(path, input);
                        Garage<Vehicle> listGarage = new Garage<Vehicle>(loadList);
                        GarageMenu(listGarage);
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
                    "7. Save garage list\n" +
                    "8. Exit application\n");
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
                        Console.WriteLine("Please enter search phrase, you can search for multiple phrases at once by seperating them with a space\n");
                        string searchinput = Console.ReadLine();
                        thisgarage.SearchVehicle(searchinput);
                        continue;
                    case 4:
                        Console.WriteLine("What type of vehicle do you want to add to the garage?\n" +
                            "1. Bicycle\n" +
                            "2. Bus\n" +
                            "3. Car\n" +
                            "4. Motorcycle\n" +
                            "5. Truck\n");
                        int chooseVehicle = int.Parse(Console.ReadLine());
                        switch (chooseVehicle)
                        {
                            case 1:
                                thisgarage.AddVehicle(thisgarage.MakeBicycle());
                                break;
                            case 2:
                                thisgarage.AddVehicle(thisgarage.MakeBus());
                                break;
                            case 3:
                                thisgarage.AddVehicle(thisgarage.MakeCar());
                                break;
                            case 4:
                                thisgarage.AddVehicle(thisgarage.MakeMotorcycle());
                                break;
                            case 5:
                                thisgarage.AddVehicle(thisgarage.MakeTruck());
                                break;
                        }
                        continue;
                    case 5:
                        Program.PopulateGarage(thisgarage);
                        continue;
                    case 6:
                        Console.WriteLine("Enter name of savefile for this garage\n");
                        string garageName = Console.ReadLine();
                        //SaveLoadJson.SerializeJSON(path, garageName, thisgarage);
                        break;
                    case 7:
                        Console.WriteLine("Enter savefile name for this list\n");
                        string listName = Console.ReadLine();
                        SaveLoadJson.SerializeJSONList(path, listName, thisgarage.ParkedVehicles);
                        break;
                    case 8:
                        quitApplication = true;
                        break;
                }
            } while (!quitApplication);
        }
        public Vehicle CreateVehicleMenu()
        {
            Vehicle returnVehicle = null;
            return returnVehicle;
        }
    }
}
