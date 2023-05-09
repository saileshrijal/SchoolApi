using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SchoolApi.Dtos;
using SchoolApi.Repository.Interface;
using SchoolApi.Services.Interface;
using SchoolApi.ViewModels;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamTypeController : ControllerBase
    {
        private readonly IExamTypeRepository _examTypeRepository;
        private readonly IExamTypeService _examTypeService;

        public ExamTypeController(IExamTypeRepository examTypeRepository, IExamTypeService examTypeService)
        {
            _examTypeRepository = examTypeRepository;
            _examTypeService = examTypeService; 
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExamTypeVM vm)
        {
            try
            {
                var examTypeDto = new ExamTypeDto
                {
                    Name = vm.Name,
                };
                await _examTypeService.CreateAsync(examTypeDto);
                return Ok($"exam type {vm.Name} created successfully");
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
                var listOfExamTypes = await _examTypeRepository.GetAll();
                var results = listOfExamTypes.Select(x => new {
                    x.Id,
                    x.Name
                });

                return Ok(results); 
            }catch (Exception ex) {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ExamTypeVM vm) {
            try
            {
                var examType = await _examTypeRepository.Get(x => x.Id == id);
                var examTypeDto = new ExamTypeDto { Name = vm.Name, };
                await _examTypeService.UpdateAsync(id,examTypeDto);
                return Ok("Exam type updated successfully");
               
            }catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            try {
                await _examTypeService.DeleteAsync(id);
                return Ok("Deleted successfully");
            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
