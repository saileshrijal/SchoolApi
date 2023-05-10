using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Dtos;
using SchoolApi.Repository.Interface;
using SchoolApi.Services.Interface;
using SchoolApi.ViewModels;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamRepository _examRepository;
        private readonly IExamService _examService;

        public ExamController(IExamRepository examRepository, IExamService examService)
        {
            _examRepository = examRepository;
            _examService = examService; 
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamVM vm)
        {
            try {
                var examDto = new ExamDto { 
                    Name = vm.Name,
                    ExamTypeId = vm.ExamTypeId,
                    AttendanceFrom = vm.AttendanceFrom, 
                    AttendanceTo = vm.AttendanceTo,
                    SchoolDays = vm.SchoolDays,
                    ResultActive = vm.ResultActive
                };
                await _examService.CreateAsync(examDto);
                return Ok("Exam created successfully");
            
            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try{
                var listOfExams = await _examRepository.GetAllExams();
                var results = listOfExams.Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.AttendanceFrom,
                    x.AttendanceTo,
                    x.SchoolDays,
                    x.ResultActive,
                    ExamType = new
                    {
                        x.ExamType!.Id,
                        x.ExamType.Name,
                    }
                }).ToList();

                return Ok(results);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
