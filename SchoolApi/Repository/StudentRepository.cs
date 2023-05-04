using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;

namespace SchoolApi.Repository
{
    public class StudentRepository:Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context):base(context)
        {
            
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students!
                                 .Include(x => x.ParentStudents)!
                                 .ThenInclude(x => x.Parent)
                                 .Include(x => x.Grade).ToListAsync();
        }
    }
}
