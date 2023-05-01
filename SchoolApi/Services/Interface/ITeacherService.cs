using SchoolApi.Dtos;
using SchoolApi.Result;

namespace SchoolApi.Services.Interface
{
    public interface ITeacherService
    {
        Task Create(TeacherDto teacherDto);
    }
}
