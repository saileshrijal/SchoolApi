using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpPost("{gradeId}")]
        public async Task<IActionResult> Assign(int gradeId, AssignSubjectVM vm)
        {
            if (!ModelState.IsValid) { return BadRequest("not valid"); }
            try
            {
                await _gradeService.AssignSubjectsToGrade(gradeId, vm.SubjectIds!);
                return Ok("subjects assign to grade");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGradesWithSubjects()
        {
            try
            {
                var gradesWithSubjects = await _gradeRepository.GetAllGradesWithSubjects();
                var result = gradesWithSubjects.Select(g => new
                {
                    Grade = new
                    {
                        g.Id,
                        g.Name,
                        g.Description,
                    },
                    Subjects = g.SubjectGrades!.Select(s => new { s.Subject!.Id, s.Subject.Name, s.Subject.Description })
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGradeWithSubjectsById(int id)
        {
            try
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
                    Subjects = gradesWithSubjects.SubjectGrades!.Select(sg => new
                    {
                        sg.Subject!.Id,
                        sg.Subject.Name,
                        sg.Subject.Description
                    })
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
