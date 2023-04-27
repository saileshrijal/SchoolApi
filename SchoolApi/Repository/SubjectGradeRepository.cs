using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;

namespace SchoolApi.Repository
{
    public class SubjectGradeRepository :Repository<SubjectGrade>, ISubjectGradeRepository
    {
        public SubjectGradeRepository(ApplicationDbContext context):base(context)
        {
            
        }
        public async Task<List<SubjectGrade>> GetSubjectGrades()
        {
            return await _context.SubjectGrades!.Include(s => s.Grade).Include(s => s.Subject).ToListAsync();
        }

        public async Task<List<Subject>> GetSubjectsByGradeId(int gradeId) {
            return await _context.SubjectGrades!.Where(s => s.GradeID == gradeId)!.Select(s => s.Subject)!.ToListAsync();
        }
    }
}
