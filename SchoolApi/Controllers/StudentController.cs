using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Dtos;
using SchoolApi.Helpers;
using SchoolApi.Helpers.Interface;
using SchoolApi.Repository.Interface;
using SchoolApi.Services;
using SchoolApi.Services.Interface;
using SchoolApi.ViewModels;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;
        private readonly IParentRepository _parentRepository;
        private readonly IFileHelper _fileHelper;
        public StudentController(IStudentService studentService, IStudentRepository studentRepository, IParentRepository parentRepository, IFileHelper fileHelper)
        {
            _studentService = studentService;
            _studentRepository = studentRepository;
            _parentRepository = parentRepository;
            _fileHelper = fileHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepository.GetAllStudents();
            var results = students.Select(x => new
            {
                x.Id,
                x.FullName,
                x.Status,
                x.CreatedDate,
                x.DateOfBirth,
                x.ProfilePictureUrl,
                x.UserName,
                x.Email,
                x.PhoneNumber,
                Grade = new
                {
                    x.Grade!.Id,
                    x.Grade.Name,
                },
                Parents = x.ParentStudents!.Select(x => new
                {
                    x.Parent!.Id,
                    x.Parent.FullName,
                })
            });
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StudentVM vm)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                foreach(var item in vm.ParentIds!)
                {
                    if(!await _parentRepository.IsAnyById(item))
                    {
                        return BadRequest($"Parent Id: {item} does not Exists");
                    }
                }
                var studentDto = new StudentDto
                {
                   UserName = vm.UserName,
                   FullName = vm.FullName,
                   Address = vm.Address,
                   Email = vm.Email,
                   ParentIds = vm.ParentIds,
                   GradeId = vm.GradeId,
                   Password = vm.Password,
                   DateOfBirth = vm.DateOfBirth,
                   PhoneNumber = vm.PhoneNumber
                };
                if (vm.ProfilePicture != null)
                {
                    studentDto.ProfilePictureUrl = await _fileHelper.UploadFile(vm.ProfilePicture, "teachers");
                }
                await _studentService.Create(studentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
