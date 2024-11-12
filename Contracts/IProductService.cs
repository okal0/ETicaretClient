using ETicaretClient.Models.Product;
using ETicaretClient.Services.models;

namespace ETicaretClient.Contracts
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();

        public Task<Product> GetProduct(string id);

        public Task<Product> CreateProduct(Product product);

        public Task<Product> UpdateProduct(Product product);

        public Task<Product> DeleteProduct(string id);
    }
}
