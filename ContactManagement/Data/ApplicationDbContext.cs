using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Contact> Contacts => Set<Contact>();
    
    public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options) { }
    
    public  ApplicationDbContext() { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
            .HasIndex(c => c.ContactNumber)
            .IsUnique();

        modelBuilder.Entity<Contact>()
            .HasIndex(c => c.Email)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Contact>().HasQueryFilter(c => !c.IsActive);
        modelBuilder.Entity<Contact>().HasData(
            new Contact { Id = 1, Name = "Exemplo Contacto", ContactNumber = "912345678", Email = "exemplo@teste.pt" }
        );
        
    }
}