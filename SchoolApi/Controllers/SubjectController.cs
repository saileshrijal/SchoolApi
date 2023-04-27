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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ISubjectGradeRepository _subjectGradeRepository;
        public SubjectController(ISubjectService subjectService, ISubjectRepository subjectRepository)
        {
            _subjectService = subjectService;
            _subjectRepository = subjectRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubjectVM vm)
        {
            try
            {
                var subjectDto = new SubjectDto()
                {
                    Name = vm.Name,
                    Code = vm.Code,
                    Description = vm.Description,
                };
                await _subjectService.CreateAsync(subjectDto);
                return Ok("Subject created successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubjectVM vm)
        {
            try
            {
                var subject = await _subjectRepository.Get(x => x.Id == id);
                var subjectDto = new SubjectDto()
                {
                    Name = vm.Name,
                    Code = vm.Code,
                    Description = vm.Description,
                };
                await _subjectService.UpdateAsync(id, subjectDto);
                return Ok("Grade updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _subjectService.DeleteAsync(id);
                return Ok("deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listOfSubjects = await _subjectRepository.GetAll();
                var subjectListvm = listOfSubjects.Select(x => new SubjectVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Description = x.Description,
                });
                return Ok(subjectListvm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
