namespace SchoolApi.Models
{
    public class Teacher : ApplicationUser
    {
        public string? Designation { get; set; }
        public string? TeachingLevel { get; set; }
        //class teacher of
        public int? GradeId { get; set; }
        public Grade? Grade { get; set; }
    }
}
