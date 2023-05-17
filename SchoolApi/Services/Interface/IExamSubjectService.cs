using SchoolApi.Dtos;

namespace SchoolApi.Services.Interface
{
    public interface IExamSubjectService
    {
        Task CreateAsync(ExamSubjectDto examSubjectDto);
    }
}
