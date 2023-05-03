using SchoolApi.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.ViewModels
{
    public class ParentVM
    {
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "FullName is required")]
        public string? FullName { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        public string? PhoneNumber { get; set; }
    }
}
