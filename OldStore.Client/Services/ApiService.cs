using OldStore.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OldStore.Client.Services
{
    public class ApiService
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<CatalogModel> GetHomeCatalog()
        {
            var parameters = new Dictionary<string, string>
            {
            };

            var responseJson = await this.RequestAsync("catalogs/home", parameters);

            var br = JsonSerializer.Deserialize<Response<CatalogModel>>(responseJson);

            return br.Result;
        }


        private async Task<string> RequestAsync(string method, Dictionary<string, string> parameters)
        {

            var prms = string.Empty;

            foreach(var parameter in parameters)
            {
                prms += $"{parameter.Key}={parameter.Value}&";
            }

            var url = $"http://localhost:5000/api/{method}?{prms}";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();


            return responseBody;
        }
    }
}
