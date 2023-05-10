using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;

namespace SchoolApi.Repository
{
    public class ExamRepository: Repository<Exam>, IExamRepository
    {

        public ExamRepository(ApplicationDbContext context):base(context) { }

        public async Task<bool> IsAnyById(int id)
        {
            return await _context.ExamTypes!.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Exam>> GetAllExams()
        {
            return await _context.Exams!.Include(x => x.ExamType).ToListAsync();
        }

    }
}
