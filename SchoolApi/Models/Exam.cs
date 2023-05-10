namespace SchoolApi.Models
{
    public class Exam
    {
        public int Id { get; set; } 
        public string? Name { get; set; }    
        public int ExamTypeId { get; set; }
        public DateTime AttendanceFrom { get; set; }
        public DateTime AttendanceTo { get; set; }
        public int SchoolDays { get; set; } 
        public bool ResultActive { get; set; }    
        public ExamType? ExamType { get; set; }  
    }
}
