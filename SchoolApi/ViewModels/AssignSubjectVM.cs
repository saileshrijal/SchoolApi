using SchoolApi.Models;

namespace SchoolApi.ViewModels
{
    public class AssignSubjectVM
    {
        public int GradeId { get; set; }
        public List<int>? SubjectIds { get; set; }

    }
}
