using System.ComponentModel.DataAnnotations;

namespace SchoolApi.ViewModels
{
    public class SubjectVM
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
