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
        public async Task<IActionResult> Assign(int id, AssignSubjectVM vm)
        {
            if (!ModelState.IsValid) { return BadRequest("not valid"); }

            try
            {
                await _gradeService.AssignSubjectsToGrade(id, vm.SubjectIds!);
                return Ok("subjects assign to grade");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGradeWithSubjects()
        {
            var gradesWithSubjects = await _gradeRepository.GetAllGradesWithSubjects();
            var result = gradesWithSubjects.Select(g => new
            {
                Grade = new {
                    g.Id,
                    g.Name,
                    g.Description,
                },
                Subjects = g.SubjectsGrade!.Select(s => new { s.Subject!.Id, s.Subject.Name, s.Subject.Description })
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGradeWithSubjectsById(int id)
        {
            var gradesWithSubjects = await _gradeRepository.GetGradeWithSubjects(id);
            if (gradesWithSubjects == null)
            {
                return BadRequest("Not found");
            }

            var result = new
            {
                Grade = new
                {
                    gradesWithSubjects.Id,
                    gradesWithSubjects.Name,
                    gradesWithSubjects.Description,
                },
                Subjects = gradesWithSubjects.SubjectsGrade!.Select(sg => new
                {
                    sg.Subject!.Id,
                    sg.Subject.Name,
                    sg.Subject.Description
                })
            };

            return Ok(result);
        }
    }
}
