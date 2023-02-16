using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class Grade
    {
        public int Id { get; set; } 
        public string? ClassName { get; set; }
        public string? Section { get; set; }
        public int NumberOfStudents { get; set; }
    }
}
