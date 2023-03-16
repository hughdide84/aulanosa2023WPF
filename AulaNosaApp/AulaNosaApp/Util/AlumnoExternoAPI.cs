using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace AulaNosaApp.Util
{
    internal class AlumnoExternoAPI
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public AlumnoExternoAPI(string baseUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _baseUrl = baseUrl;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{endpoint}");
            response.EnsureSuccessStatusCode();
            var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseStream);
        }

        public async Task<T> PostAsync<T>(string endpoint, object data)
        {
            var requestContent = new StringContent(JsonSerializer.Serialize(data));
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/{endpoint}", requestContent);
            response.EnsureSuccessStatusCode();
            var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseStream);
        }

        public async Task PutAsync(string endpoint, object data)
        {
            var requestContent = new StringContent(JsonSerializer.Serialize(data));
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/{endpoint}", requestContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string endpoint)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{endpoint}");
            response.EnsureSuccessStatusCode();
        }

    }
}
