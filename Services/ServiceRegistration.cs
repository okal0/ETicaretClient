using ETicaretClient.Services.common;

namespace ETicaretClient.Services
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHttpClient<HttpClientService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7089");
            });
        }
    }
}
