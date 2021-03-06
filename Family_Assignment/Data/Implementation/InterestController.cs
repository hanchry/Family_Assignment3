using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Family_Assignment.Data.Implementation
{
    public class InterestController : IInterestController
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;


        public InterestController()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);
        }

        public async Task AddInterestAsync(int childId, Interest interest)
        {
            string serializedPet = JsonConvert.SerializeObject(interest);
            StringContent content = new StringContent(serializedPet, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Interest/{childId}", content);
        }

        public async Task RemoveInterestAsync(int id)
        {
            await client.DeleteAsync($"{uri}/Interest/{id}");
        }
    }
}