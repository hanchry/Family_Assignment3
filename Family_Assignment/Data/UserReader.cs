using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Family_Assignment.Data
{
    public class UserReader : IUserReader
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;


        public UserReader()
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            client = new HttpClient(clientHandler);
        }


        public async Task<User> ValidateUser(string userName, string password)
        {
            HttpResponseMessage responseMessage =
                await client.GetAsync(uri + $"/User/{userName}");
            string replyMessage = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception(replyMessage);
            }
            //Throwing an exception
          //  User user = JsonSerializer.Deserialize<User>(replyMessage);
          User user = JsonConvert.DeserializeObject<User>(replyMessage);
                
            if (!user.Password.Equals(password))
            {
                throw new Exception("Incorrect password !");
            }

            
            return user;
        }

        public async Task<User> RegisterUser(string userName, string password)
        {
            User user = new User();
            user.UserName = userName;
            user.Password = password;

            string serializedUser = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/User/newUser", content);
            String reply = await responseMessage.Content.ReadAsStringAsync();
           if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine(reply);
                throw new Exception(reply);
            }

            return user;
        }
    }
}