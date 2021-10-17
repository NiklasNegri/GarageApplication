using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace GarageApplication
{
    public static class SaveLoadJson
    {
        public static void SerializeJSON(string path, string filename, Garage<Vehicle> garage)
        {
            string jsonString = JsonConvert.SerializeObject(garage);
            File.WriteAllText(path + filename + ".json", jsonString);
        }
        public static Garage<Vehicle> LoadJSON(string path, string filename)
        {
            string jsonText = File.ReadAllText(path + filename);
            Garage<Vehicle> loadGarage = JsonConvert.DeserializeObject<Garage<Vehicle>>(jsonText);
            return loadGarage;
        }
        public static void FindAllSavedFiles(string path)
        {
            string[] itterateDirectory = Directory.GetFiles(path);
            foreach (var file in itterateDirectory)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
    }
}
