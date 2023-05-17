using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Dtos;
using SchoolApi.Services;
using SchoolApi.Services.Interface;
using SchoolApi.ViewModels;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamSubjectController : ControllerBase
    {
        private readonly IExamSubjectService _examSubject;
        public ExamSubjectController(IExamSubjectService examSubject)
        {
            _examSubject = examSubject; 
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamSubjectVM vm)
        {
            try
            {
                var examSubjectDto = new ExamSubjectDto
                {
                    GradeId = vm.GradeId,
                    SubjectId = vm.SubjectId,   
                    FinalTheoryFullMarks = vm.FinalTheoryFullMarks,
                    FinalPracticalFullMarks = vm.FinalPracticalFullMarks,
                    CreditHour = vm.CreditHour  
                };
                await _examSubject.CreateAsync(examSubjectDto);
                return Ok("Exam with subject created successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
