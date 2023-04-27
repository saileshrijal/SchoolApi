using Microsoft.AspNetCore.Mvc;
using SchoolApi.Repository.Interface;
using SchoolApi.Services.Interface;
using SchoolApi.ViewModels;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectGradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly IGradeRepository _gradeRepository;
        private readonly ISubjectRepository _subjectRepository;

        public SubjectGradeController(IGradeService gradeService, IGradeRepository gradeRepository, ISubjectRepository subjectRepository)
        {
            _gradeService = gradeService;
            _gradeRepository = gradeRepository;
            _subjectRepository = subjectRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Assign(AssignSubjectVM vm)
        {
            if (!ModelState.IsValid) { return BadRequest("not valid"); }

            try
            {
                await _gradeService.AssignSubjectsToGrade(vm.GradeId, vm.SubjectIds!);
                return Ok("subjects assign to grade");
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
