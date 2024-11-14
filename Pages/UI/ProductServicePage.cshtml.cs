using ETicaretClient.Contracts;
using ETicaretClient.Services.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETicaretClient.Pages.UI
{
    public class ProductServicePageModel : PageModel
    {
        private readonly IProductService _productService;

        public ProductServicePageModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public string ProductId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Page { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int Size { get; set; } = 10;

        public List<Product> Products { get; set; }

        public string ReturnMessage { get; set; }

        public async Task<IActionResult> OnPostCreateProductAsync()
        {
            var result = await _productService.CreateProduct(Product);
            ReturnMessage = "Product Created: " + result.Name;
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteProductAsync()
        {
            var result = await _productService.DeleteProduct(ProductId);
            ReturnMessage = "Product Deleted: " + result.Name;
            return Page();
        }

        public async Task<IActionResult> OnPostGetProductAsync()
        {
            Product = await _productService.GetProduct(ProductId);
            ReturnMessage = "Product Retrieved: " + Product.Name;
            return Page();
        }

        public async Task<IActionResult> OnPostGetProductsAsync()
        {
    
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateProductAsync()
        {
            var result = await _productService.UpdateProduct(Product);
            ReturnMessage = "Product Updated: " + result.Name;
            return Page();
        }
    }
}
