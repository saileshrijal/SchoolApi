using System.ComponentModel.DataAnnotations;

namespace SchoolApi.ViewModels
{
    public class ExamVM
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int ExamTypeId { get; set; }
        public DateTime AttendanceFrom { get; set; }
        public DateTime AttendanceTo { get; set; }
        public int SchoolDays { get; set; }
        public bool ResultActive { get; set; }
    }
}
