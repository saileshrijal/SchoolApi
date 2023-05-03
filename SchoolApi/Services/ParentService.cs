using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Constants;
using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Services.Interface;
using System.Transactions;

namespace SchoolApi.Services
{
    public class ParentService: IParentService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ParentService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Create(ParentDto parentDto) {
            using var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await Validate(parentDto.UserName,parentDto.Email);
            var parent = new Parent()
            {
                UserName = parentDto.UserName,
                Email = parentDto.Email,
                FullName = parentDto.FullName,
                Address = parentDto.Address,
                PhoneNumber = parentDto.PhoneNumber,
                Status = true,
                CreatedDate = DateTime.Now
            };
            await _userManager.CreateAsync(parent, parentDto.Password!);
            await _userManager.AddToRoleAsync(parent, UserRole.Parent);
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
