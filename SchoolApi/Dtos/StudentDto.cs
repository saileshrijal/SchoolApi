namespace SchoolApi.Dtos
{
    public class StudentDto
    {
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string>? ParentIds { get; set; }
        public int GradeId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
