using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Anshan.Framework.SpecFlow
{
    public static class HttpExtension
    {
        public static async Task Put<TRequest>(this HttpClient client, string url, TRequest body)
        {
            var myContent = JsonConvert.SerializeObject(body);
            var response = await client.PutAsync(url, new StringContent(myContent, Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ReasonPhrase);
        }

        public static async Task<TResponse> Post<TRequest, TResponse>(this HttpClient client, string url, TRequest body)
        {
            var myContent = JsonConvert.SerializeObject(body);
            var response = await client.PostAsync(url, new StringContent(myContent, Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsJsonAsync<TResponse>();

            if (response.IsSuccessStatusCode)
                return result;

            throw new Exception(response.ReasonPhrase);
        }

        public static async Task Post<TRequest>(this HttpClient client, string url, TRequest body)
        {
            var myContent = JsonConvert.SerializeObject(body);
            var response = await client.PostAsync(url, new StringContent(myContent, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ReasonPhrase);
        }

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }
    }
}