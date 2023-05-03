namespace SchoolApi.Models
{
    public class Student:ApplicationUser
    {
        public List<ParentStudent>? ParentStudents { get; set; }
    }
}
