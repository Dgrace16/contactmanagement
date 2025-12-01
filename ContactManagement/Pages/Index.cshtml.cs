using ContactManagement.Data;
using ContactManagement.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public IndexModel(ApplicationDbContext db) { _db = db; }

    public IList<Contact> Contacts { get; set; } =  new List<Contact>();
    public async Task OnGetAsync()
    {
        Contacts = await _db.Contacts.OrderBy(c => c.Name).ToListAsync();
    }
}