using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace GarageApplication
{
    public static class SaveLoadJson
    {
        public static void SerializeJSONList(string path, string filename, List<Vehicle> vehicles)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string jsonString = JsonConvert.SerializeObject(vehicles, settings);
            File.WriteAllText(path + filename + ".json", jsonString);
        }
        public static List<Vehicle> LoadJSONList(string path, string filename)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string jsonText = File.ReadAllText(path + filename);
            List<Vehicle> loadedList = JsonConvert.DeserializeObject<List<Vehicle>>(jsonText, settings);
            return loadedList;
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
