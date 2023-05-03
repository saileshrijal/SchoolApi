using Microsoft.AspNetCore.Identity;
using SchoolApi.Constants;
using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Seeder.Interface;
using SchoolApi.Services.Interface;

namespace SchoolApi.Seeder
{
    public class UserSeeder: IUserSeeder
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;

        public UserSeeder(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,IUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
        }

        public async Task SeedAdminuser()
        {
            var adminUser = await _userManager.GetUsersInRoleAsync(UserRole.Admin);
            if (!adminUser.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
                await _roleManager.CreateAsync(new IdentityRole(UserRole.User));
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Teacher));
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Parent));
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Parent));
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Student));

                var userDto = new UserDto()
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    FullName = "Super Admin",
                    Status = true,
                    UserRole = UserRole.Admin,
                    Password = "@Admin123"
                };
                await _userService.Create(userDto);
            }
            else
            {
                throw new Exception("Admin user already exists");
            }
        }
    }
}
