namespace SchoolApi.ViewModels
{
    public class StudentVM
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string>? ParentIds { get; set; }
    }
}
