using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DogRestCustomer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using(var httpClient = new HttpClient())
            {
                HttpResponseMessage response;

                try
                {
                    response = await httpClient.GetAsync("https://localhost:44364/api/dogs");

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Error");
                        return;
                    }
                    string json = await response.Content.ReadAsStringAsync();

                    var dogs = JsonConvert.DeserializeObject<List<ApiDog>>(json);

                    foreach (var dog in dogs)
                    {
                        Console.WriteLine($"Dog #{dog.Id}, {dog.Name}");
                    }

                    var newDog = new ApiDog { Name = "Nick" };

                    string postJson = JsonConvert.SerializeObject(newDog);

                    var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44364/api/dogs");

                    request.Content = new StringContent(postJson, Encoding.UTF8, "application/json");

                    var response2 = await httpClient.SendAsync(request);

                    if (!response2.IsSuccessStatusCode)
                    {

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
