﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                        
        }
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<Grade>? Grades { get; set; }
        public DbSet<SubjectGrade>? SubjectGrades { get; set; }
        public DbSet<Teacher>? Teachders { get; set; }
        public DbSet<Parent>? Parents { get; set; }
        public DbSet<Student>? Students { get; set; }   
        public DbSet<ParentStudent>? ParentStudents{ get; set; }
        public DbSet<ExamType>? ExamTypes { get; set; }
        public DbSet<Exam>? Exams { get; set; } 
    }
}
