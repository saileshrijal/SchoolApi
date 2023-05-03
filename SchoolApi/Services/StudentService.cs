using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Constants;
using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Repository;
using SchoolApi.Repository.Interface;
using SchoolApi.Services.Interface;
using SchoolApi.ViewModels;
using System.Transactions;

namespace SchoolApi.Services
{
    public class StudentService:IStudentService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStudentRepository _studentRepository;

        public StudentService(UserManager<ApplicationUser> userManager, IStudentRepository studentRepository)
        {
            _userManager = userManager;
            _studentRepository = studentRepository;
        }

        public async Task Create(StudentDto studentDto) {
            using var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await Validate(studentDto.UserName, studentDto.Email);
            var student = new Student()
            {
                FullName = studentDto.FullName,
                Email = studentDto.Email,
                Address = studentDto.Address,
                DateOfBirth = studentDto.DateOfBirth,
                UserName = studentDto.UserName,
                PhoneNumber = studentDto.PhoneNumber,
                CreatedDate = DateTime.Now,
                Status = true,
                GradeId = studentDto.GradeId,
            };
            if (studentDto.ParentIds!.Any())
            {
                student.ParentStudents = studentDto.ParentIds!.Select(x => new ParentStudent
                {
                    ParentId = x,
                    StudentId = student.Id
                }).ToList();
            }
            await _userManager.CreateAsync(student);
            await _userManager.AddToRoleAsync(student, UserRole.Student);
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
