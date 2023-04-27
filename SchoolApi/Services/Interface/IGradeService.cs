using SchoolApi.Dtos;

namespace SchoolApi.Services.Interface
{
    public interface IGradeService
    {
        Task CreateAsync(GradeDto gradeDto);
        Task UpdateAsync(int id, GradeDto gradeDto);
        Task DeleteAsync(int id);
        Task AssignSubjectsToGrade(int gradeId, List<int> subectIds);
    }
}
