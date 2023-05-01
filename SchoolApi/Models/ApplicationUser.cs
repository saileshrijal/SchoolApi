using Microsoft.AspNetCore.Identity;

namespace SchoolApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set;}
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
