using PagedList;
using SchoolApi.Models;

namespace SchoolApi.Repository.Interface
{
    public interface IGradeRepository:IRepository<Grade>
    {
        Task<List<Grade>> GetAllGradesWithSubjects();
        Task<Grade> GetGradeWithSubjects(int id);
    }
}
