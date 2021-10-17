using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace GarageApplication
{
    public static class SaveLoadJson
    {
        // SerializeJSON sparar Garage objektet till JSON fil
        public static void SerializeJSON(string path, string filename, Garage<Vehicle> garage)
        {
            string jsonString = JsonConvert.SerializeObject(garage);
            File.WriteAllText(path + filename + ".json", jsonString);
        }
        // laddar ett Garage från JSON fil
        public static Garage<Vehicle> LoadJSON(string path, string filename)
        {
            string jsonText = File.ReadAllText(path + filename);
            Garage<Vehicle> loadGarage = JsonConvert.DeserializeObject<Garage<Vehicle>>(jsonText);
            return loadGarage;
        }
        // spottar ut alla sparade garage som finns i foldern SavedGarages där progremmet körs ifrån
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
