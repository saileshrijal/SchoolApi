namespace SchoolApi.Models
{
    public class ExamType
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<Exam>? Exams { get; set; }
    }
}
