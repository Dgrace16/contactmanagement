using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ContactManagement.Pages.Account
{
    public class Login : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;

        private readonly IConfiguration _config;
        public Login(IConfiguration config) { _config = config; }

        public void OnGet(string? returnUrl = null) { }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            var staticUser = _config.GetSection("Auth:StaticUser");
            if (Username == staticUser["Username"] && Password == staticUser["Password"])
            {
                var claims = new[] { new Claim(ClaimTypes.Name, Username) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                if (!string.IsNullOrEmpty(returnUrl)) return LocalRedirect(returnUrl);
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError("", "you are can not here");
            return Page();
        }
    }
}