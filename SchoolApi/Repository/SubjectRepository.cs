using SchoolApi.Data;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;

namespace SchoolApi.Repository
{
    public class SubjectRepository:Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
