using System.ComponentModel.DataAnnotations;

namespace SchoolApi.ViewModels
{
    public class StudentVM
    {
        [Required(ErrorMessage = "Full Name is required")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Grade is required")]
        public int GradeId { get; set; }
        public List<string>? ParentIds { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
