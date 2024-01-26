using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBankAPI.Data.Entities;
using OnlineBankAPI.Models;

namespace OnlineBankAPI.Data;

public sealed class ApplicationContext : IdentityDbContext<User>
{
    public DbSet<Account> Accounts { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserClaim<string>>()
            .HasKey(x => new { x.Id });
        
        modelBuilder.Entity<User>()
            .ToTable("users")
            .HasKey(x => x.Id);

        modelBuilder.Entity<Account>()
            .ToTable("accounts")
            .HasOne<User>(x => x.User)
            .WithOne(x => x.Account)
            .HasForeignKey<Account>(x => x.UserId);

        modelBuilder.Entity<Account>()
            .HasKey(x => x.Id);
        
        base.OnModelCreating(modelBuilder);
    }
}