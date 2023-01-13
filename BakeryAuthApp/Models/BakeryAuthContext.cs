using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BakeryAuth.Models 
{
  public class BakeryAuthContext : IdentityDbContext<ApplicationUser>
  {
    // public DbSet<ClassName> ClassNames { get; set; }   CHANGE CLASS NAME!!!

    public BakeryAuthContext(DbContextOptions options) : base(options) { } 
  }
}
