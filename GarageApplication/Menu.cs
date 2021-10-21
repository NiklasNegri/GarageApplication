using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GarageApplication
{
    /// <summary>
    /// Class Menu creates the UI with 2 different menus that are used in the program.
    /// </summary>
    public class Menu
    {
        UserInputHelper userInputHelper = new UserInputHelper();

        // Path gets the users path to the folder that the program is running from, and adds a new folder named SavedGarages to it.
        public string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SavedGarages\\";

        // The default constructor of Menu creates the folder named SavedGarages when the program is run the first time 
        // which lets the user load and save his Garages in.
        public Menu()
        {
            Directory.CreateDirectory(path);
        }
        /// <summary>
        /// The first menu to be run where it just asks the user if he wants to create a new garage or load an old saved one.
        /// In case of user input error user is asked to make new input
        /// </summary>
        public void StartMenu()
        {
            bool quitStartMenu = false;          
            do
            {
                Console.WriteLine("Welcome to garage simulator!\n" +
                "1. Create new garage\n" +
                "2. Load saved list\n" +
                "3. Exit application\n");
                int userChoice = userInputHelper.ParseIntInput();
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("How many vehicles can be parked in the garage?\n");
                        int garageSpace = userInputHelper.ParseIntInput();
                        Garage<Vehicle> newGarage = new Garage<Vehicle>(garageSpace);
                        GarageMenu(newGarage);
                        quitStartMenu = true;
                        break;
                    case 2:
                        // IN CASE OF USER ERROR HERE THE PROGRAM RETURNS TO FIRST MENU
                        Console.WriteLine("Previously saved garages:\n");
                        SaveLoadJson.FindAllSavedFiles(path);
                        Console.WriteLine("\nWhich one do you want to load? Only enter filename without .json\n");
                        string input = userInputHelper.ParseStringInput() + ".json";
                        if (File.Exists(path + input))
                        {
                            var loadList = SaveLoadJson.LoadJSONList(path, input);
                            Garage<Vehicle> listGarage = new Garage<Vehicle>(loadList);
                            Console.WriteLine($"\n\n ----- LOADING GARAGE WITH FILENAME { input } -----\n\n");
                            GarageMenu(listGarage);
                            quitStartMenu = true;
                        }
                        else
                        {
                            Console.WriteLine($"\nFile with name\n\n{ input }\n\nnot found in\n\n{ path }\n");
                            Console.WriteLine("Returning to start menu!\n");
                        }          
                        break;
                    case 3:
                        quitStartMenu = true;
                        break;
                }
            } while (!quitStartMenu);
        }
        /// <summary>
        /// GarageMenu is the menu run when the user has selected and entered his garage and it contains
        /// all methods that lets the user interact with the garages functions.
        /// </summary>
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
                    "5. Remove a vehicle from garage\n" +
                    "6. Save garage list\n" +
                    "7. Populate the garage with pre-created vehicles\n" +
                    "8. Exit application\n");
                int userChoice = userInputHelper.ParseIntInput();
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
                        int chooseVehicle = userInputHelper.ParseIntInput();
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
                        Console.WriteLine("\nVehicle added!");
                        continue;
                    case 5:
                        thisgarage.ListVehicle();
                        Console.WriteLine("What item would you like to remove? Enter a number:");
                        int listIndex = userInputHelper.FixIndexPosParseIntInput();
                        thisgarage.RemoveVehicle(listIndex);
                        continue;
                    case 6:
                        Console.WriteLine("Enter savefile name for this list\n");
                        string listName = userInputHelper.ParseStringInput();
                        SaveLoadJson.SerializeJSONList(path, listName, thisgarage.ParkedVehicles);
                        Console.WriteLine($"Savefile with name { listName } created!\n");
                        break;
                    case 7:
                        PopulateGarage(thisgarage);
                        Console.WriteLine("Garage populated!\n");
                        continue;
                    case 8:
                        quitApplication = true;
                        
                        break;
                }
            } while (!quitApplication);
        }
        /// <summary>
        /// Populates the ParkedVehicles list in Garage with pre-determined objects of each Vehicle type.
        /// </summary>
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
