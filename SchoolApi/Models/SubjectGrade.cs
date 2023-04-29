namespace SchoolApi.Models
{
    public class SubjectGrade
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }  
        public int GradeId { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual Grade? Grade { get; set; }
    }
}
