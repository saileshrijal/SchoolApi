namespace SchoolApi.Dtos
{
    public class ChangePasswordDto
    {
        public string? UserId { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassWord { get; set; }
    }
}
