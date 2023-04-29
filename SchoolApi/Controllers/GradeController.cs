using Microsoft.AspNetCore.Mvc;
using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;
using SchoolApi.Services.Interface;
using SchoolApi.ViewModels;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly IGradeRepository _gradeRepository;
        public GradeController(IGradeService gradeService, IGradeRepository gradeRepository)
        {
            _gradeService = gradeService;
            _gradeRepository = gradeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(GradeVM vm) {
            try
            {
                var gradeDto = new GradeDto()
                {
                    Name = vm.Name,
                    Description = vm.Description,
                };
                await _gradeService.CreateAsync(gradeDto);
                return Ok("Grade created successfully");

            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,GradeVM vm)
        {
            try
            {
                var grade = await _gradeRepository.Get(x => x.Id == id);
                var gradeDto = new GradeDto()
                {
                    Name = vm.Name,
                    Description = vm.Description,
                };
                await _gradeService.UpdateAsync(id,gradeDto);
                return Ok("Grade updated successfully");
            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            try
            {
                await _gradeService.DeleteAsync(id);
                return Ok("deleted successfully");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listOfGrades = await _gradeRepository.GetAll();
                var results = listOfGrades.Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Description,
                });
                return Ok(results); 
            }catch (Exception ex) {
                return BadRequest(ex.Message);  
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var grade = await _gradeRepository.GetById(id);
                var result = new
                {
                    grade.Id,
                    grade.Name,
                    grade.Description
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
