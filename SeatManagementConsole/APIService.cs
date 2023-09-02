﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole
{
    public class APIService : IAPIService
    {
        private readonly HttpClient client;
        public string baseUrl;
        public string apiEndpoint;
        public APIService(string apiEndpoint)
        {
           baseUrl = "https://localhost:7102/api/";
           this.apiEndpoint = apiEndpoint;
            client = new HttpClient();
        }

     
        public async Task Post<T>(T newObject)
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

        
        public async Task<List<T>> GetAll<T>()
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


        //Generic GetById 
        public async Task<T> GetById<T>(int id)
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
                        return default(T); //returns default value for T
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"An error occurred with configurations of API");
                    return default(T);
                }
            
        }

        //Generic Put
        public async Task Put<T>(T newObject)
        {
            
                try
                {
                    string jsonObject = JsonConvert.SerializeObject(newObject);

                    // StringContent -> HTTP Content as a string -> Creates an HTTP Format to store the jsonObject
                    // 3 params -> the json object, encoding to be used, content/type
                    StringContent content = new StringContent(jsonObject, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(baseUrl + apiEndpoint, content);

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
}
