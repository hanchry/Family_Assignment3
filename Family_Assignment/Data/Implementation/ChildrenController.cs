using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Family_Assignment.Data.Implementation
{
    public class ChildrenController :IChildrenController
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;


        public ChildrenController()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);
        }
        public async Task AddChildAsync(string streetName, int houseNumber, Child child)
        {
            string serializedChild = JsonConvert.SerializeObject(child);
            StringContent content = new StringContent(serializedChild, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Family/Child/{streetName}/{houseNumber}", content);
        }

        public async Task RemoveChildAsync(int id)
        {
            await client.DeleteAsync($"{uri}/Family/Child/{id}");
        }
    }
}