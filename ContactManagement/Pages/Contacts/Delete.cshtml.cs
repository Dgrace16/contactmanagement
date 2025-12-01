using ContactManagement.Data;
using ContactManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Pages.Contacts
{
    public class Delete : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Delete(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Contact? Contact { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contact = await _db.Contacts.FirstOrDefaultAsync(c => c.Id == id);

            if (Contact == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var contact = await _db.Contacts.FindAsync(id);

            if (contact == null)
                return NotFound();

            contact.IsActive= false;

            await _db.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}