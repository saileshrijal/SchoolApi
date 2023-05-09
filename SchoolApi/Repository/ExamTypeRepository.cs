using SchoolApi.Data;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;

namespace SchoolApi.Repository
{
    public class ExamTypeRepository:Repository<ExamType>, IExamTypeRepository
    {
        public ExamTypeRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
