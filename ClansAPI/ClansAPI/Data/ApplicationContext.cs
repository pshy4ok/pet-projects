using ClansAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClansAPI.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Clan> Clans { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clan>().ToTable("clans")
            .HasKey(c => c.Id);
    }
}