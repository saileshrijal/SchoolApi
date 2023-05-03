using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Dtos;
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
        private readonly ITeacherRepository _teacherRepository;
        private readonly IParentRepository _parentRepository;
        public StudentController(IStudentService studentService, ITeacherRepository teacherRepository, IParentRepository parentRepository)
        {
            _studentService = studentService;
            _teacherRepository = teacherRepository;
            _parentRepository = parentRepository;
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
