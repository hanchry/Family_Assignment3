using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Family_Assignment.Data.Implementation
{
    public class JobController :IJobController
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;


        public JobController()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);
        }
        
        public async Task AddJobAsync(int adultId, Job job)
        {
            string serializedJob = JsonConvert.SerializeObject(job);
            StringContent content = new StringContent(serializedJob, Encoding.UTF8, "application/json");
            await client.PostAsync($"{uri}/Job/{adultId}", content);
        }

        public async Task RemoveJobAsync(int id)
        {
            await client.DeleteAsync($"{uri}/Job{id}");
        }
    }
}