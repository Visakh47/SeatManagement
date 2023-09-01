using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole
{
    public class APIService : IAPIService
    {
        public string baseUrl;
        public string apiEndpoint;
        public APIService(string apiEndpoint)
        {
           baseUrl = "https://localhost:7102/api/";
           this.apiEndpoint = apiEndpoint;
        }

        //Generic Post
        public async Task Post<T>(T newObject)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonObject = JsonConvert.SerializeObject(newObject);

                    // StringContent -> HTTP Content as a string -> Creates an HTTP Format to store the jsonObject
                    // 3 params -> the json object, encoding to be used, content/type
                    StringContent content = new StringContent(jsonObject, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(baseUrl + apiEndpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Created successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("An error occurred in API Configurations");
                }
            }
        }

        //Generic Get
        public async Task<List<T>> GetAll<T>()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(baseUrl + apiEndpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        // Within the response header, we have content of the response.
                        string content = await response.Content.ReadAsStringAsync();

                        List<T> objects = JsonConvert.DeserializeObject<List<T>>(content);

                        return objects;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return null;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"An error occurred with configurations of API");
                    return null;
                }
            }
        }


        //Generic GetById 
        public async Task<T> GetById<T>(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{baseUrl}{apiEndpoint}/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Within the response header, we have content of the response.
                        string content = await response.Content.ReadAsStringAsync();

                        T obj = JsonConvert.DeserializeObject<T>(content);

                        return obj;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return default(T); // Return default value for type T (usually null for reference types).
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"An error occurred with configurations of API");
                    return default(T); // Return default value for type T (usually null for reference types).
                }
            }
        }

    }
}
