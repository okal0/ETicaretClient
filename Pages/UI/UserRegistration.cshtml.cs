using ETicaretClient.Contracts;
using ETicaretClient.Models.Product;
using ETicaretClient.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ETicaretClient.Pages.UI
{
    public class UserRegistrationModel : PageModel
    {
        private readonly IUserService _userService;

        public UserRegistrationModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserInfo NewUser { get; set; }
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
                var createdProduct = await _userService.CreateUser(NewUser);
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
