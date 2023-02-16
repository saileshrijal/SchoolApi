

namespace School.Models
{
    public class Bus
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? ImeiNo { get; set; }
        public int StaffId { get; set; }
        public Staff? Staff { get; set;}
    }
}
