
namespace ETicaretClient.Contracts
{
    public interface IProductService
    {
        public Task<ProductResponse> GetProducts(int page, int size);

        public Task<Product> GetProduct(string id);

        public Task<Product> CreateProduct(Product product);

        public Task<Product> UpdateProduct(Product product);

        public Task<Product> DeleteProduct(string id);
    }
}
