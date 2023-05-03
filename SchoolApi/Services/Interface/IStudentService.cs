using SchoolApi.Dtos;

namespace SchoolApi.Services.Interface
{
    public interface IStudentService
    {
        Task Create(StudentDto studentDto);
    }
}
