namespace SchoolApi.Dtos
{
    public class ExamSubjectDto
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int GradeId { get; set; }
        public double FinalTheoryFullMarks { get; set; }
        public double FinalPracticalFullMarks { get; set; }
        public int CreditHour { get; set; }
    }
}
