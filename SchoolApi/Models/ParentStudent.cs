namespace SchoolApi.Models
{
    public class ParentStudent
    {
        public int Id { get; set; }
        public string? StudentId { get; set; }
        public string? ParentId  { get; set;}
        public virtual Parent? Parent { get; set; }  
        public virtual Student? Student { get; set; }
    }
}

