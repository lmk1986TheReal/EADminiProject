using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using EADMiniProject.Models;

namespace EADMiniProject
{
    class Test

    {
        static void Main()
        {


            //AddAsync().Wait();
            GetAllAsync().Wait();
            Console.ReadKey();
        }
        static async Task GetAllAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:18373/");                             // base URL for API Controller i.e. RESTFul service

                    // add an Accept header for JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // GET ../api/stock
                    // get all stock listings
                    HttpResponseMessage response = await client.GetAsync("api/ClientApi");                  // async call, await suspends until result available            
                    if (response.IsSuccessStatusCode)                                                   // 200..299
                    {
                        Console.WriteLine("The following is a list of all the the bands in the database and each of their repsective nationalities");

                        // read result 
                        var bands = await response.Content.ReadAsAsync<IEnumerable<Band>>();
                        foreach (var band in bands)
                        {
                            Console.WriteLine(band.BandName + " - " + band.Nationality);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
