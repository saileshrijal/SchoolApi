using SchoolApi.Models;

namespace SchoolApi.Repository.Interface
{
    public interface ISubjectGradeRepository:IRepository<SubjectGrade>
    {
        Task<List<SubjectGrade>> GetSubjectGrades();
        Task<List<Subject>> GetSubjectsByGradeId(int gradeId);
    }
}
