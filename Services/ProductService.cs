using ETicaretClient.Contracts;
using ETicaretClient.Services.Base;
using ETicaretClient.Services.models;

namespace ETicaretClient.Services
{
    public class ProductService : BaseHttpService, IProductService
    {
        public ProductService(IClient httpClient) : base(httpClient)
        {
    
        }

        public Task<Product> CreateProduct(Product product)
        {
            requestParams.Controller = "Products";
            return _client.PostAsync(requestParams, product);
        }

        public Task<Product> DeleteProduct(string id)
        {
            return _client.DeleteAsync<Product>(requestParams, id);
        }

        public Task<Product> GetProduct(string id)
        {
            return _client.GetAsync<Product>(requestParams, id);
        }

        public Task<List<Product>> GetProducts()
        {
            return _client.GetAsync<List<Product>>(requestParams);
        }

        public Task<Product> UpdateProduct(Product product)
        {
            return _client.PutAsync(requestParams, product);
        }
    }
}
