
namespace School.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Designation { get; set; }
        public string? TeachingLevel { get; set; }
        public string? GradeId { get; set; } //class teacher of this grade
        public Grade? Grade { get; set; }
        public int Rank { get; set; }
        public string? FingerprintId { get; set; }
        public string? ImageUrl { get; set; }
        public Position? Position { get; set; }
    }

    public enum Position
    {
        Teacher = 0,
        Accountant = 1,
    }
}
