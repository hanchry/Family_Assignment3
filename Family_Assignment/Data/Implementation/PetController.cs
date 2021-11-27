using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Family_Assignment.Data.Implementation
{
    public class PetController : IPetController
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;


        public PetController()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);
        }

        public async Task AddChildPetAsync(int childId, Pet pet)
        {
            string serializedPet = JsonConvert.SerializeObject(pet);
            StringContent content = new StringContent(serializedPet, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Pet/Child/{childId}", content);
        }

        public async Task AddFamilyPetAsync(string streetName, int houseNumber, Pet pet)
        {
            string serializedPet = JsonConvert.SerializeObject(pet);
            StringContent content = new StringContent(serializedPet, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Pet/Family/{streetName}/{houseNumber}", content);
        }

        public async Task RemovePetAsync(int id)
        {
            await client.DeleteAsync($"{uri}/Pet/{id}");

        }
    }
}