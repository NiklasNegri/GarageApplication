using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace GarageApplication
{
    /// <summary>
    /// This class is used to create and load JSON files that represent saved versions of different garages
    /// </summary>
    public static class SaveLoadJson
    {
        /// <summary>
        /// Creates the Serialzed JSON version of the current garages list that is going to be saved.
        /// </summary>
        public static void SerializeJSONList(string path, string filename, List<Vehicle> vehicles)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string jsonString = JsonConvert.SerializeObject(vehicles, settings);
            File.WriteAllText(path + filename + ".json", jsonString);
        }
        /// <summary>
        /// De-serialzes the JSON file of the garages list that is being loaded.
        /// </summary>
        public static List<Vehicle> LoadJSONList(string path, string filename)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string jsonText = File.ReadAllText(path + filename);
            List<Vehicle> loadedList = JsonConvert.DeserializeObject<List<Vehicle>>(jsonText, settings);
            return loadedList;
        }
        /// <summary>
        /// Itterates through all names of saved JSON garages.
        /// </summary>
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
