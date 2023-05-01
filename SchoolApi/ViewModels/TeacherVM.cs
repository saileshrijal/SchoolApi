using SchoolApi.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.ViewModels
{
    public class TeacherVM
    {
        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Designation { get; set; }
        public string? TeachingLevel { get; set; }
        public int? GradeId { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        public string? PhoneNumber { get; set; }
    }
}
