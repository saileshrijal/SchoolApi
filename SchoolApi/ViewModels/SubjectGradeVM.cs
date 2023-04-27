using SchoolApi.Models;

namespace SchoolApi.ViewModels
{
    public class SubjectGradeVM
    {
        public List<Grade>? Grades { get; set; }
        public List<Subject>? Subjects { get; set; }
    }
}
