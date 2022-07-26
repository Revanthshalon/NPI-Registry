using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NPI_Registry.Web
{
    internal class API
    {
        private static HttpClient GetHttpClient(string url)
        {
            var client = new HttpClient() { BaseAddress=new Uri(url) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static async Task<T> GetAsync<T>(string url, string urlParameters)
        {
            try
            {
                using(var client = GetHttpClient(url))
                {
                    var response = await client.GetAsync(urlParameters);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<T>(json);
                        return result ?? default;
                    }
                    else
                    {
                        throw new Exception($"{response.StatusCode}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }

        public static async Task<T> RunAsync<T>(string url, string urlParamters)
        {
            var response = await GetAsync<T>(url, urlParamters);
            return response;
        }
    }
}
