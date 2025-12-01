using ContactManagement.Data;
using ContactManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Pages.Contacts
{
    public class Create : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Create(ApplicationDbContext db) { _db = db; }

        [BindProperty]
        public Contact Contact { get; set; } = new Contact();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            
            if (await _db.Contacts.AnyAsync(c => c.ContactNumber == Contact.ContactNumber))
            {
                ModelState.AddModelError(nameof(Contact.ContactNumber), "this number is already in use.");
                return Page();
            }
            if (await _db.Contacts.AnyAsync(c => c.Email == Contact.Email))
            {
                ModelState.AddModelError(nameof(Contact.Email), "this email is already in use.");
                return Page();
            }

            _db.Contacts.Add(Contact);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}