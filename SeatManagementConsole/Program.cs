using Newtonsoft.Json;
using SeatManagementAPI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static string baseUrl = "https://localhost:7102/api/";
    public static async Task GetAllBuildings() {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl + "buildings");

                if (response.IsSuccessStatusCode)
                {
                    //within the response header, we have content of response. 
                    string content = await response.Content.ReadAsStringAsync();

                    List<Building> buildings = JsonConvert.DeserializeObject<List<Building>>(content);

                    foreach (var building in buildings)
                    {
                        Console.WriteLine($"BuildingId: {building.BuildingId}");
                        Console.WriteLine($"BuildingName: {building.BuildingName}");
                        Console.WriteLine($"BuildingAbbreviation: {building.BuildingAbbreviation}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
                Thread.Sleep(500000);
            }
            catch (Exception)
            {
                Console.WriteLine($"An error occurred with configurations of API");
                Thread.Sleep(500000);
            }
        }
    }
    public static async Task AddBuilding()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                Building newBuilding = new Building
                {
                    BuildingName = "KINFRA",
                    BuildingAbbreviation = "KFA"
                };

                string jsonObject = JsonConvert.SerializeObject(newBuilding);


                //StringContent -> HTTP Content as a string -> Creates an HTTP Format to store the jsonObject
                // 3 params -> the json object, encoding to be used, content/type
                StringContent content = new StringContent(jsonObject, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(baseUrl + "buildings", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Building created successfully.");
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
    public static void Main(string[] args)
    {
        //AddBuilding().Wait();
        GetAllBuildings().Wait();
    }
}

