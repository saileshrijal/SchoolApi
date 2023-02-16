namespace School.Models
{
    public class BusStop
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public int BusId { get; set; }
        public Bus? Bus { get; set; }
    }
}
