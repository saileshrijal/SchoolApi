using SchoolApi.Models;

namespace SchoolApi.Dtos
{
    public class TeacherDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Designation { get; set; }
        public string? TeachingLevel { get; set; }
        //class teacher of
        public int? GradeId { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
