namespace SchoolApi.Models
{
    public class Student : ApplicationUser
    {
        public int GradeId { get; set; }
        public Grade? Grade { get; set; }
        public List<ParentStudent>? ParentStudents { get; set; }
    }
}
