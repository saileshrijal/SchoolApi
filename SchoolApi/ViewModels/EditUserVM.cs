using System.ComponentModel.DataAnnotations;
namespace SchoolApi.ViewModels
{
    public class EditUserVM
    {
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }
    }
}
