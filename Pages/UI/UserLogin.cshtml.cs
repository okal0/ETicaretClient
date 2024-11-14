using ETicaretClient.Contracts;
using ETicaretClient.Contracts.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ETicaretClient.Pages.UI
{
    public class UserLoginModel : PageModel
    {
        private readonly IUserService _userService;
        UserLogin NewUser = new UserLogin();
        string Message { get; set; }
        UserLoginModel(IUserService userService)
        {
            _userService = userService;
        }



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Use the service for log-in
                
                Message = "Baþarýyla giriþ yaptýnýz!";
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
