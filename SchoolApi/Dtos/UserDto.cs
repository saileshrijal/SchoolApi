﻿namespace SchoolApi.Dtos
{
    public class UserDto
    {
        public string? FullName { get; set; }
        public string? UserName { get; set;}
        public string? Email { get; set;}
        public string? Password { get; set;}
        public string? UserRole { get; set; }
        public bool Status { get; set; }
    }
}
