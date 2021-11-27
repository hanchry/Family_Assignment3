using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Family_Assignment.Data.Implementation
{
    public class AdultController : IAdultController
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;


        public AdultController()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);
        }


        public async Task AddAdultAsync(string streetName, int houseNumber, Adult adult)
        {
            string serializedAdult = JsonConvert.SerializeObject(adult);
            StringContent content = new StringContent(serializedAdult, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Family/Adult/{streetName}/{houseNumber}", content);
        }

        public async Task RemoveAdultAsync(int id)
        {
            await client.DeleteAsync($"{uri}/Family/Adult/{id}");
        }
    }
}