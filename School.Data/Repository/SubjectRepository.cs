using School.Data.IRepository;
using School.Models;


namespace School.Data.Repository
{
    public class SubjectRepository:GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
