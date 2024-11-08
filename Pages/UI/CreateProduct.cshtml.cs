using ETicaretClient.Models.Product;
using ETicaretClient.Services.common;
using ETicaretClient.Services.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ETicaretClient.Pages.UI
{
    public class CreateProductModel : PageModel
    {
        private readonly HttpClientService _httpClientService;

        public CreateProductModel(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
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

            // Set up request parameters
            var requestParams = new RequestParameters
            {
                Controller = "products",  // Adjust based on your API
            };

            try
            {
                // Use the custom HttpClientService to send the POST request
                var createdProduct = await _httpClientService.PostAsync(requestParams, product);
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
