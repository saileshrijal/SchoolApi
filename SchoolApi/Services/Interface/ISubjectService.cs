using SchoolApi.Dtos;

namespace SchoolApi.Services.Interface
{
    public interface ISubjectService
    {
        Task CreateAsync(SubjectDto subjectDto);
        Task UpdateAsync(int id, SubjectDto subjectDto);
        Task DeleteAsync(int id);
    }
}
