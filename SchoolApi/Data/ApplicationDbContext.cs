using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                        
        }
        public DbSet<Parent>? Parents { get; set; }
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
