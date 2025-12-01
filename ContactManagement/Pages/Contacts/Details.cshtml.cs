using ContactManagement.Data;
using ContactManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManagement.Pages.Contacts
{
    public class Details : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Details(ApplicationDbContext db) { _db = db; }

        public Contact? Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contact = await _db.Contacts.FindAsync(id);
            if (Contact == null) return NotFound();
            return Page();
        }
    }
}