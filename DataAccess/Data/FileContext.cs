using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace FamilyWebApi.Data
{
    public class FileContext
    {
        public IList<Family> Families { get; set; }
        public IList<User> Users { get; private set; }

        private readonly string familiesFile = "Data/JsonFiles/families.json";
        private readonly string usersFile = "Data/JsonFiles/users.json";


        
        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Users = File.Exists(usersFile) ? ReadData<User>(usersFile) : new List<User>();

        }
        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }
        public void SaveChanges()
        {
            //Sending family IList to families.json file
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }
            
            //Sending users IList to users.json file
            string jsonUsers = JsonSerializer.Serialize(Users, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile1 = new StreamWriter(usersFile, false))
            {
                outputFile1.Write(jsonUsers);
            }
            
        }
    }
}