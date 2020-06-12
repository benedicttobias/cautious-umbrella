using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Triton.Data
{
    public class NewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("newsApi");
        }

        public async Task<NewsApiModel> Get(string country, string keyword)
        {
            try
            {
                var response = await _httpClient.GetAsync($"?country={country}&q={keyword}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<NewsApiModel>();
                }

                return null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
