
namespace School.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public int GradeId { get; set; }
        public Grade? Grade { get; set; }   
        public int RollNo { get; set; }
        public int MotherId { get; set; }
        public Parent? Mother { get; set; }
        public int FatherId { get; set; }
        public Parent? Father { get; set; }
        public int GuardianId { get; set; }
        public Parent? Guardian { get; set; }
        public int BusStopId { get; set; }
        public BusStop? BusStop { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? SymbolNumber { get; set; }
        public string? Batch { get; set; }
        public string? House { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PermanentAddress { get; set; }
        public string? TemporaryAddress { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string? BloodGroup { get; set; }
        public string? Religion { get; set; }
        public string? Nationality { get; set; }
        public string? ImageUrl { get; set; }
    }
}
