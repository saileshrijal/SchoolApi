namespace SchoolApi.Dtos
{
    public class StudentDto
    {
        public int fatherId;

        public int motherId;
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
