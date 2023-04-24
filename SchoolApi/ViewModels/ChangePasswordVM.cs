﻿using System.ComponentModel.DataAnnotations;

namespace SchoolApi.ViewModels
{
    public class ChangePasswordVM
    {
        public string? OldPassword { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters, contain at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string? NewPassword { get; set; }
    }
}
