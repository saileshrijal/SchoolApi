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

            var student = new Student()
            {
                FullName = studentDto.FullName,
                Email = studentDto.Email,
                Address = studentDto.Address,
                DateOfBirth = studentDto.DateOfBirth,
            };

        }
    }
}
