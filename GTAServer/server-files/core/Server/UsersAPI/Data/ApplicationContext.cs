using Microsoft.EntityFrameworkCore;
using UsersAPI.Data.Entities;

namespace UsersAPI.Data;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("user")
            .HasKey(c => c.Id);
    }
}