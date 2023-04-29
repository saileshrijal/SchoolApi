using System.ComponentModel.DataAnnotations;

namespace SchoolApi.ViewModels
{
    public class GradeVM
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
