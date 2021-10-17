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
        public void StartMenu()
        {
            bool quitStartMenu = false;
            Console.WriteLine("Gör ett val i menyn!\n" +
                "1. Starta nytt garage\n" +
                "2. Ladda gammalt garage\n" +
                "3. Stäng programmet");
            do
            {
                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Hur många platser finns i garaget?\n");
                        int garageSpace = int.Parse(Console.ReadLine());
                        Garage<Vehicle> newGarage = new Garage<Vehicle>(garageSpace);
                        GarageMenu(newGarage);
                        quitStartMenu = true;
                        break;
                    case 2:
                        Console.WriteLine("Dessa garage finns sparade:\n");
                        SaveLoadJson.FindAllSavedFiles(path);
                        Console.WriteLine("Vilket vill du ladda?\n");
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
        public void GarageMenu(Garage<Vehicle> garage)
        {
            Garage<Vehicle> thisgarage = garage;
            bool quitApplication = false;
            do
            {
                Console.WriteLine("Gör ett val i menyn!\n" +
                    "1. Print all vehicles in garage\n" +              
                    "2. Save garage\n" + 
                    "3. Quit\n" + 
                    "4. Add a vehicle to garage\n");
                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        thisgarage.ListVehicle();
                        continue;
                    case 2:
                        Console.WriteLine("Vad vill du döpa garaget till?\n");
                        string garageName = Console.ReadLine();
                        SaveLoadJson.SerializeJSON(path, garageName, thisgarage);
                        break;
                    case 3:
                        quitApplication = true;
                        break;
                    case 4:
                        thisgarage.AddVehicle(new Car("Volvo", "123456", "Blue", 4, 450, false));
                        continue;
                }
            } while (!quitApplication);
        }
    }
}
