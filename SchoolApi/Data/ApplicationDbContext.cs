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
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<Grade>? Grades { get; set; }
        public DbSet<SubjectGrade>? SubjectGrades { get; set; }
        public DbSet<Teacher>? Teachders { get; set; }
    }
}
