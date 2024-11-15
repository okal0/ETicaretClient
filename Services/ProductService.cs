using ETicaretClient.Contracts;
using ETicaretClient.Services.Base;
using ETicaretClient.Services.models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETicaretClient.Services
{
    public class ProductService : BaseHttpService, IProductService
    {
        public ProductService(IClient httpClient) : base(httpClient)
        {
        }

        public async Task<Product> CreateProduct(Product product)
        {
            requestParams.Controller = "Products";
            requestParams.Action = null;
            requestParams.QueryString = null;
            var response = await _client.PostAsync<Product, Product>(requestParams, product);

            if (response.IsSuccess)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"API call failed with message: {response.ErrorMessage}");
            }
        }

        public async Task<Product> DeleteProduct(string id)
        {
            requestParams.Controller = "Products";
            requestParams.Action = null;
            requestParams.QueryString = null;
            var response = await _client.DeleteAsync<Product>(requestParams, id);

            if (response.IsSuccess)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"API call failed with message: {response.ErrorMessage}");
            }
        }

        public async Task<Product> GetProduct(string id)
        {
            requestParams.Controller = "Products";
            requestParams.Action = null;
            requestParams.QueryString = null;
            var response = await _client.GetAsync<Product>(requestParams, id);

            if (response.IsSuccess)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"API call failed with message: {response.ErrorMessage}");
            }
        }

        public async Task<ProductResponse> GetProducts(int page, int size)
        {
            requestParams.Controller = "Products";
            requestParams.Action = null;
            requestParams.QueryString = $"Page={page}&Size={size}";
            var response = await _client.GetAsync<ProductResponse>(requestParams);

            if (response.IsSuccess)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"API call failed with message: {response.ErrorMessage}");
            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            requestParams.Controller = "Products";
            requestParams.Action = null;
            requestParams.QueryString = null;
            var response = await _client.PutAsync<Product, Product>(requestParams, product);

            if (response.IsSuccess)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"API call failed with message: {response.ErrorMessage}");
            }
        }
    }
}
