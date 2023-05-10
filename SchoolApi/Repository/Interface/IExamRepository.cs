using SchoolApi.Models;

namespace SchoolApi.Repository.Interface
{
    public interface IExamRepository: IRepository<Exam>
    {
        Task<bool> IsAnyById(int id);
        Task<List<Exam>> GetAllExams();
    }
}
