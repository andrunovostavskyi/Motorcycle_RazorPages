using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Motorcycle.Pages.AuthPages
{
    [Authorize(Roles = "Admin")]
    public class AddRolesModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly MotoContext _motoContext;

        public AddRolesModel(UserManager<IdentityUser> userManager, MotoContext motoContext)
        {
            _userManager = userManager;
            _motoContext = motoContext;
        }

        [BindProperty]
        public InputModel? Input { get; set; } 

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = default!;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _motoContext.Users.FirstOrDefaultAsync(u => u.Email == Input!.Email);
                if (user != null)
                {
                    var result = await _userManager.AddToRoleAsync(user, "Admin");
                    if (result.Succeeded)
                    {
                        return RedirectToPage("/AuthPages/Login");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("Input.Email", "User with this email not found.");
                }
            }
            return Page();
        }
    }
}
