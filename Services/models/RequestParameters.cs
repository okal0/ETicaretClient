using System.Net.Http.Headers;

namespace ETicaretClient.Services.models
{
    public class RequestParameters
    {
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? QueryString { get; set; }
        public HttpHeaders? Headers { get; set; }
        public string? BaseUrl { get; set; }
        public string? FullEndPoint { get; set; }
        public string? ResponseType { get; set; } = "json";
    }
}
