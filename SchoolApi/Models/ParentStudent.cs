namespace SchoolApi.Models
{
    public class ParentStudent
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ParentId  { get; set;}
        public virtual Parent? Parent { get; set; }  
        public virtual Student? Student { get; set; }
    }
}

