using ETicaretClient.Models;
using ETicaretClient.Services.models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ETicaretClient.Services.Base
{
    public partial interface IClient
    {
        public Task<ApiResponse<TResponse>> GetAsync<TResponse>(RequestParameters requestParameters, string id = null);
        public Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(RequestParameters requestParameters, TRequest body);
        public Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(RequestParameters requestParameters, TRequest body);
        public Task<ApiResponse<TResponse>> DeleteAsync<TResponse>(RequestParameters requestParameters, string id);
    }

    public partial class Client : IClient
    {
        protected readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseUrl = httpClient.BaseAddress.ToString();
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

        public async Task<ApiResponse<TResponse>> GetAsync<TResponse>(RequestParameters requestParameters, string id = null)
        {
            string url = BuildUrl(requestParameters) + (id != null ? $"/{id}" : "");

            if (requestParameters.Headers != null)
            {
                _httpClient.DefaultRequestHeaders.Clear();
                foreach (var header in requestParameters.Headers)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            var response = await _httpClient.GetAsync(url);
            return await CreateApiResponse<TResponse>(response);
        }

        public async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(RequestParameters requestParameters, TRequest body)
        {
            string url = BuildUrl(requestParameters);

            if (requestParameters.Headers != null)
                _httpClient.DefaultRequestHeaders.Clear();

            if (requestParameters.Headers != null)
            {
                foreach (var header in requestParameters.Headers)
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            Console.WriteLine($"Request URL: {url}"); // Log the URL

            var response = await _httpClient.PostAsJsonAsync(url, body);
            return await CreateApiResponse<TResponse>(response);
        }

        public async Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(RequestParameters requestParameters, TRequest body)
        {
            string url = BuildUrl(requestParameters);

            if (requestParameters.Headers != null)
                _httpClient.DefaultRequestHeaders.Clear();

            foreach (var header in requestParameters.Headers)
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            var response = await _httpClient.PutAsJsonAsync(url, body);
            return await CreateApiResponse<TResponse>(response);
        }

        public async Task<ApiResponse<TResponse>> DeleteAsync<TResponse>(RequestParameters requestParameters, string id)
        {
            string url = BuildUrl(requestParameters) + $"/{id}";

            if (requestParameters.Headers != null)
                _httpClient.DefaultRequestHeaders.Clear();

            foreach (var header in requestParameters.Headers)
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            var response = await _httpClient.DeleteAsync(url);
            return await CreateApiResponse<TResponse>(response);
        }

        private async Task<ApiResponse<TResponse>> CreateApiResponse<TResponse>(HttpResponseMessage response)
        {
            var apiResponse = new ApiResponse<TResponse>
            {
                IsSuccess = response.IsSuccessStatusCode
            };

            if (response.IsSuccessStatusCode)
            {
                apiResponse.Data = await response.Content.ReadFromJsonAsync<TResponse>();
            }
            else
            {
                apiResponse.ErrorMessage = await response.Content.ReadAsStringAsync();
            }

            return apiResponse;
        }
    }
}
