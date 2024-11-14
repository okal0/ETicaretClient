using ETicaretClient.Contracts;
using ETicaretClient.Services.Base;
using ETicaretClient.Services.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ETicaretClient.Pages.UI
{
    public class CreateProductModel : PageModel
    {
        private readonly IProductService _productService;

        public CreateProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product product { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Use the custom HttpClientService to send the POST request
                var createdProduct = await _productService.CreateProduct(product);
                Message = "Product created successfully!";
               
            }
            catch (Exception ex)
            {
                Message = $"Error: {ex.Message}";
            }

            return Page();
        }

        public void OnGet()
        {
        }
    }
}
