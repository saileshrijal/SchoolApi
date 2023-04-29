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
    }
}
