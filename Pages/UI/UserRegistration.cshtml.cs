using ETicaretClient.Contracts;
using ETicaretClient.Contracts.User;
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

            
            Console.WriteLine($"New User Information: {NewUser}");
            try
            {
                // Use the custom HttpClientService to send the POST request
                var createdUser = await _userService.CreateUser(NewUser);
                Message = "User created successfully!";
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
