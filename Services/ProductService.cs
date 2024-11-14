using ETicaretClient.Contracts;
using ETicaretClient.Services.Base;
using ETicaretClient.Services.models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            requestParams.Action = null;
            requestParams.QueryString = null;
            return _client.PostAsync<Product, Product>(requestParams, product);
        }

        public Task<Product> DeleteProduct(string id)
        {
            requestParams.Controller = "Products";
            requestParams.Action = null;
            requestParams.QueryString = null;
            return _client.DeleteAsync<Product>(requestParams, id);
        }

        public Task<Product> GetProduct(string id)
        {
            requestParams.Controller = "Products";
            requestParams.Action = null;
            requestParams.QueryString = null;
            return _client.GetAsync<Product>(requestParams, id);
        }

        public Task<ProductResponse> GetProducts(int page, int size)
        {
            requestParams.Controller = "Products";
            requestParams.Action = null;
            requestParams.QueryString = $"Page={page}&Size={size}";
            return _client.GetAsync<ProductResponse>(requestParams);
        }

        public Task<Product> UpdateProduct(Product product)
        {
            requestParams.Controller = "Products";
            requestParams.Action = null;
            requestParams.QueryString = null;
            return _client.PutAsync<Product, Product>(requestParams, product);
        }
    }
}
