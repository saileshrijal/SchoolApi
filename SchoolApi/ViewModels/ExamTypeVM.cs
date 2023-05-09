using System.ComponentModel.DataAnnotations;

namespace SchoolApi.ViewModels
{
    public class ExamTypeVM
    {
        [Required]
        public string? Name { get; set; }
    } 
}
