using ETicaretClient.Contracts;
using ETicaretClient.Contracts.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ETicaretClient.Pages.UI
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        public UserLogin Input = new UserLogin();
        public string Message { get; set; }
        public LoginModel(IUserService userService) => _userService = userService;
        public string ReturnUrl { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var user = await _userService.UserLogin(Input);
                if (user != null)
                {
                    Message = "You are in successfully!";
                    return RedirectToPage("./CreateProduct");
                }
                else
                {
                    Message = "Invalid login attempt.";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                Message = $"Error: {ex.Message}";
                return Page();
            }
        }

        public void OnGet()
        {
        }
    }
}
