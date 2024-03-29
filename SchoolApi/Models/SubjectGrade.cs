﻿using System.Runtime.ConstrainedExecution;

namespace SchoolApi.Models
{
    public class SubjectGrade
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }  
        public int GradeId { get; set; }
        public double FinalTheoryFullMarks { get; set; }
        public double FinalPracticalFullMarks { get; set; }
        public int CreditHour { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual Grade? Grade { get; set; }
    }
}
