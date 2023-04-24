using SchoolApi.Dtos;
using SchoolApi.Models;

namespace SchoolApi.Services.Interface
{
    public interface IUserService
    {
        Task<ApplicationUser> Create(UserDto userDto);
        Task<ApplicationUser> Update(string id, UserDto userDto);
        Task ToggleUserStatus(string id);
        Task ChangePassword(ChangePasswordDto changePasswordDto);
        Task ResetPassword(ResetPasswordDto resetPasswordDto);  
        Task UpdateProfile(UpdateProfileDto updateProfileDto);
    }
}
