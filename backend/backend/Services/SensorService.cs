using backend.Interfaces;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace backend
{
    public class SensorService : ISensor
    {
        public SensorService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        private readonly HttpClient _httpClient;

        // This would be normally loaded out of azure configuration or just app settings
        // depending on security considerations or preferred method of loading
        public const string uri = "https://dorsavicodechallenge.azurewebsites.net/Melbourne";

        [DllImport(@"./sample.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int add(int a, int b);

        public int AddUsingC(int a, int b)
        {
            return add(a, b);
        }

        public async Task<IEnumerable<Owner>> GetCats()
        {

            HttpResponseMessage response = await _httpClient.GetAsync(uri);

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var owners = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Owner>>(responseBody);

            var ownersOfCats = from owner in owners where (owner.pets?.Any(pet => pet.type == "Cat") ?? false) select owner;

            return ownersOfCats;
        }
    }
}
