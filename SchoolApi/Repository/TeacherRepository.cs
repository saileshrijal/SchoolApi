using SchoolApi.Data;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;

namespace SchoolApi.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
