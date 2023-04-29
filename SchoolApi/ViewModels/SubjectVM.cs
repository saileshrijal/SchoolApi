using System.ComponentModel.DataAnnotations;

namespace SchoolApi.ViewModels
{
    public class SubjectVM
    {
        [Required]
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
