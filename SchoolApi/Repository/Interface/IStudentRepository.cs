using SchoolApi.Models;

namespace SchoolApi.Repository.Interface
{
    public interface IStudentRepository:IRepository<Student>
    {
        Task<List<Student>> GetAllStudents();
    }
}
