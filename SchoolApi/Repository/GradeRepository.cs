using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;

namespace SchoolApi.Repository
{
    public class GradeRepository :Repository<Grade>, IGradeRepository
    {
        public GradeRepository(ApplicationDbContext context):base(context)
        {
           
        }
        public async Task<List<Grade>> GetAllGradesWithSubjects()
        {
            return await _context.Grades!.Include(x => x.SubjectsGrade)!.ThenInclude(x => x.Subject).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }
        public async Task<Grade> GetGradeWithSubjects(int id)
        {
            return await _context.Grades!.Include(x => x.SubjectsGrade)!.ThenInclude(x => x.Subject)!.FirstOrDefaultAsync(x => x.Id == id)??throw new Exception("Not Found");
        }
    }
}
