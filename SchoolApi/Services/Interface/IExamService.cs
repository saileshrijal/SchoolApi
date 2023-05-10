using SchoolApi.Dtos;

namespace SchoolApi.Services.Interface
{
    public interface IExamService
    {
        Task CreateAsync(ExamDto examDto);
    }
}
