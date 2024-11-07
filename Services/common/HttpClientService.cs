using ETicaretClient.Services.models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ETicaretClient.Services.common
{


    public class HttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public HttpClientService(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        private string BuildUrl(RequestParameters requestParameters)
        {
            if (!string.IsNullOrEmpty(requestParameters.FullEndPoint))
                return requestParameters.FullEndPoint;

            string baseUrl = requestParameters.BaseUrl ?? _baseUrl;
            string url = $"{baseUrl}/{requestParameters.Controller}";

            if (!string.IsNullOrEmpty(requestParameters.Action))
                url += $"/{requestParameters.Action}";

            if (!string.IsNullOrEmpty(requestParameters.QueryString))
                url += $"?{requestParameters.QueryString}";

            return url;
        }

        public async Task<T> GetAsync<T>(RequestParameters requestParameters, string id = null)
        {
            string url = BuildUrl(requestParameters) + (id != null ? $"/{id}" : "");

            // Optional: Configure headers if provided
            if (requestParameters.Headers != null)
                _httpClient.DefaultRequestHeaders.Clear();

            foreach (var header in requestParameters.Headers)
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            return await _httpClient.GetFromJsonAsync<T>(url);
        }

        public async Task<T> PostAsync<T>(RequestParameters requestParameters, T body)
        {
            string url = BuildUrl(requestParameters);

            if (requestParameters.Headers != null)
                _httpClient.DefaultRequestHeaders.Clear();

            foreach (var header in requestParameters.Headers)
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            var response = await _httpClient.PostAsJsonAsync(url, body);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PutAsync<T>(RequestParameters requestParameters, T body)
        {
            string url = BuildUrl(requestParameters);

            if (requestParameters.Headers != null)
                _httpClient.DefaultRequestHeaders.Clear();

            foreach (var header in requestParameters.Headers)
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            var response = await _httpClient.PutAsJsonAsync(url, body);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> DeleteAsync<T>(RequestParameters requestParameters, string id)
        {
            string url = BuildUrl(requestParameters) + $"/{id}";

            if (requestParameters.Headers != null)
                _httpClient.DefaultRequestHeaders.Clear();

            foreach (var header in requestParameters.Headers)
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }

}
