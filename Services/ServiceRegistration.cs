using ETicaretClient.Contracts;
using ETicaretClient.Services.Base;

namespace ETicaretClient.Services
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddHttpClient<IClient, Client>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7089/api");
            });


            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();

        }
    }
}
