using SchoolApi.Dtos;

namespace SchoolApi.Services.Interface
{
    public interface IExamTypeService
    {
        Task CreateAsync(ExamTypeDto examTypeDto);
        Task UpdateAsync(int id, ExamTypeDto examTypeDto);
        Task DeleteAsync(int id);
    }
}
