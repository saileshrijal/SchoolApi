using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {
        }
        public DbSet<Grade>? Grades { get; set; }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<GradeSubject>? GradeSubjects { get; set; }
        public DbSet<Bus>? Buses { get; set; }
        public DbSet<BusStop>? BusStops { get; set; }
        public DbSet<Parent>? Parents { get; set; }
        public DbSet<Staff>? Staffs { get; set; }
        public DbSet<Student>? Students { get; set; }
    }
}
