using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ContactManagement.Pages.Account
{
    public class Login : PageModel
    {
        private readonly IConfiguration _config;
        public Login(IConfiguration config) { _config = config; }

        [BindProperty]
        public string Username { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        [BindProperty]
        public string? ReturnUrl { get; set; }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            var user = _config.GetSection("Auth:StaticUser:Username").Value;
            var pass = _config.GetSection("Auth:StaticUser:Password").Value;

            if (Username == user && Password == pass)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, Username) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return LocalRedirect(returnUrl);

                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Credenciais inválidas");
            return Page();
        }
    }
}