using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;


namespace Family_Assignment.Data
{
    public class FamilyReader : IFamilyReader
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;


        public FamilyReader()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);
        }

        public async Task<IList<Family>> GetAllFamiliesAsync()
        {
            List<Family> families = new List<Family>();
            HttpResponseMessage responseMessage = await client.GetAsync(uri + "/Family");
            String reply = await responseMessage.Content.ReadAsStringAsync();
            families = JsonConvert.DeserializeObject<List<Family>>(reply);
            return families;
        }

        public async Task AddFamilyAsync(Family family)
        {
            string serializedFamily = JsonConvert.SerializeObject(family);
            StringContent content = new StringContent(serializedFamily, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Family/newFamily", content);
        }

        public async Task RemoveFamilyAsync(Family family)
        {
            await client.DeleteAsync($"{uri}/Family/{family.StreetName}/{family.HouseNumber}");
        }

        public async Task UpdateFamilyAsync(Family family)
        {
            try
            {
                string serializedFamily = JsonConvert.SerializeObject(family);
                StringContent content = new StringContent(serializedFamily, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PatchAsync($"{uri}/Family/{family.StreetName}/{family.HouseNumber}", content);
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task AddChildAsync(string streetName, int houseNumber, Child child)
        {
            string serializedChild = JsonConvert.SerializeObject(child);
            StringContent content = new StringContent(serializedChild, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Family/Child/{streetName}/{houseNumber}", content);
        }
        public async Task AddChildPetAsync(int childId,
            Pet pet)
        {
            string serializedPet = JsonConvert.SerializeObject(pet);
            StringContent content = new StringContent(serializedPet, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Family/PetChild/{childId}", content);
        }
        public async Task AddFamilyPetAsync(string streetName, int houseNumber, Pet pet)
        {
            string serializedPet = JsonConvert.SerializeObject(pet);
            StringContent content = new StringContent(serializedPet, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Family/PetFamily/{streetName}/{houseNumber}", content);
        }
        

        public async Task RemoveChildAsync(int id)
        {
            await client.DeleteAsync($"{uri}/Family/Child/{id}");
        }
        public async Task RemovePetAsync(int id)
        {
            await client.DeleteAsync($"{uri}/Family/Pet/{id}");
        }
        
        public async Task UpdateChildAsync(string streetName, int houseNumber, Child child)
        {
            try
            {
                string serializedFamily = JsonConvert.SerializeObject(child);
                StringContent content = new StringContent(serializedFamily, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PatchAsync($"{uri}/Family/Child/{streetName}/{houseNumber}", content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Family> GetFamilyAsync(string streetName, int houseNumber)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/Family/{streetName}/{houseNumber}");
            String reply = await responseMessage.Content.ReadAsStringAsync();
            Family family = JsonConvert.DeserializeObject<Family>(reply);
            return family;
        }
    }
}