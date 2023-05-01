using Microsoft.AspNetCore.Identity;
using SchoolApi.Constants;
using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Result;
using SchoolApi.Services.Interface;
using System.Transactions;

namespace SchoolApi.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public TeacherService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Create(TeacherDto teacherDto)
        {
            using var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await Validate(teacherDto.UserName, teacherDto.Email);
            var teacher = new Teacher()
            {
                UserName = teacherDto.UserName,
                Email = teacherDto.Email,
                FullName = teacherDto.FullName,
                DateOfBirth = teacherDto.DateOfBirth,
                CreatedDate = DateTime.UtcNow,
                TeachingLevel = teacherDto.TeachingLevel,
                GradeId = teacherDto.GradeId,
                Designation = teacherDto.Designation,
                PhoneNumber = teacherDto.PhoneNumber,
                Status = true
            };
            if(teacherDto.ProfilePictureUrl != null )
            {
                teacher.ProfilePictureUrl = teacherDto.ProfilePictureUrl;
            }
            await _userManager.CreateAsync(teacher, teacherDto.Password!);
            await _userManager.AddToRoleAsync(teacher, UserRole.Teacher);
            tx.Complete();
        }


        private async Task Validate(string? username, string? email)
        {
            if (await _userManager.FindByNameAsync(username!) != null)
            {
                throw new Exception($"Username {username} already exists");
            }

            if (await _userManager.FindByEmailAsync(email!) != null)
            {
                throw new Exception($"Email {email} already exists");
            }
        }
    }
}
