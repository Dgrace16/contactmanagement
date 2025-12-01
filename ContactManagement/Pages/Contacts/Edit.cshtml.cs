using ContactManagement.Data;
using ContactManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Pages.Contacts
{
    public class Edit : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Edit(ApplicationDbContext db) { _db = db; }

        [BindProperty]
        public Contact Contact { get; set; } = new Contact();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var c = await _db.Contacts.FindAsync(id);
            if (c == null) return NotFound();
            Contact = c;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // uniqueness checks excluding current record
            if (await _db.Contacts.AnyAsync(x => x.ContactNumber == Contact.ContactNumber && x.Id != Contact.Id))
            {
                ModelState.AddModelError(nameof(Contact.ContactNumber), "Este contacto já existe.");
                return Page();
            }

            if (await _db.Contacts.AnyAsync(x => x.Email == Contact.Email && x.Id != Contact.Id))
            {
                ModelState.AddModelError(nameof(Contact.Email), "Este email já existe.");
                return Page();
            }

            var dbContact = await _db.Contacts.FindAsync(Contact.Id);
            if (dbContact == null) return NotFound();

            dbContact.Name = Contact.Name;
            dbContact.ContactNumber = Contact.ContactNumber;
            dbContact.Email = Contact.Email;

            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}