﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Constants;
using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Services.Interface;
using SchoolApi.ViewModels;
using System.Security.Claims;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = UserRole.Admin)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private UserManager<ApplicationUser> _userManager;

        public UserController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userManager.GetUsersInRoleAsync(UserRole.User);
            var result = users.Select(x => new { 
                x.Id,
                x.FirstName, 
                x.LastName,
                x.UserName,
                x.Email,
                x.Status,
                role = _userManager.GetRolesAsync(x).Result.FirstOrDefault()
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id) ?? throw new Exception("User not found");
                var result = new
                {
                    user!.Id,
                    user.FirstName,
                    user.LastName,
                    user.UserName,
                    user.Email,
                    user.Status,
                    role = _userManager.GetRolesAsync(user).Result.FirstOrDefault()
                };
                return Ok(result);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserVM vm)
        {
            try
            {
                var userDto = new UserDto
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    UserName = vm.UserName,
                    Email = vm.Email,
                    Password = vm.Password,
                    UserRole = UserRole.User,
                    Status = true
                };

                await _userService.Create(userDto);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, EditUserVM vm) {
            try
            {
                var userDto = new UserDto
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName
                };
                await _userService.Update(id, userDto);
                return Ok();

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> ToggleUserStatus(string id)
        {
            try {
                await _userService.ToggleUserStatus(id);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM vm) {
            try { 
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var currentUser = await CurrentUser();
                var changePasswordDto = new ChangePasswordDto
                {
                    UserId = currentUser.Id,
                    OldPassword = vm.OldPassword,
                    NewPassWord = vm.NewPassword

                };

                await _userService.ChangePassword(changePasswordDto);
                return Ok();
            }catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ResetPassword(string id, ResetPasswordVM vm)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var resetPasswordDto = new ResetPasswordDto
                {
                    UserId = id,
                    Password = vm.Password
                };
                await _userService.ResetPassword(resetPasswordDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            try
            {
                var currentUser = await CurrentUser();
                var result = new
                {
                    currentUser.FirstName,
                    currentUser.LastName,
                    currentUser.Email,
                    currentUser.UserName,
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile(EditUserVM vm)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var currentUser = await CurrentUser();
                var updateProfileDto = new UpdateProfileDto
                {
                    UserId = currentUser.Id,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                };
                await _userService.UpdateProfile(updateProfileDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<ApplicationUser> CurrentUser() {
            var claimsIdentity = (ClaimsIdentity)User.Identity!;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var username = claims!.Value;
            return await _userManager.FindByNameAsync(username) ?? new ApplicationUser();
        }

    }
}
