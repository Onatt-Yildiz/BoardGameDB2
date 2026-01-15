using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace BoardGameDB.Service
{
    public class ExternalApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.restful-api.dev/")
            };
        }

        public async Task<List<RestObjectDto>> GetObjectsAsync()
        {
            
            return await _httpClient.GetFromJsonAsync<List<RestObjectDto>>("objects");
        }
    }

    public class RestObjectDto
    {
        [JsonPropertyName("id")] 
        public string Id { get; set; }

        [JsonPropertyName("name")] 
        public string Name { get; set; }

        [JsonPropertyName("data")] 
        public Dictionary<string, object> Data { get; set; }
    }
}