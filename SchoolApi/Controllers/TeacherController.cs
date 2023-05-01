using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Dtos;
using SchoolApi.Helpers.Interface;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;
using SchoolApi.Services.Interface;
using SchoolApi.ViewModels;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IFileHelper _fileHelper;
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherService teacherService, IFileHelper fileHelper, ITeacherRepository teacherRepository)
        {
            _teacherService = teacherService;
            _fileHelper = fileHelper;
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherRepository.GetAll();
            var results = teachers.Select(x => new
            {
                x.Id,
                x.FullName,
                x.Designation,
                x.TeachingLevel,
                x.GradeId,
                x.Status,
                x.CreatedDate,
                x.DateOfBirth,
                x.ProfilePictureUrl,
                x.UserName,
                x.Email,
                x.PhoneNumber
            });
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]TeacherVM vm)
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                var teachderDto = new TeacherDto
                {
                    UserName = vm.UserName,
                    Email = vm.Email,
                    FullName = vm.FullName,
                    DateOfBirth = vm.DateOfBirth,
                    Designation = vm.Designation,
                    TeachingLevel = vm.TeachingLevel,
                    GradeId = vm.GradeId,
                    Password = vm.Password,
                    PhoneNumber = vm.PhoneNumber
                };
                if (vm.ProfilePicture != null)
                {
                    teachderDto.ProfilePictureUrl = await _fileHelper.UploadFile(vm.ProfilePicture, "teachers");
                }
                await _teacherService.Create(teachderDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
