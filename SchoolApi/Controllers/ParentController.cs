using Microsoft.AspNetCore.Mvc;
using SchoolApi.Dtos;
using SchoolApi.Repository.Interface;
using SchoolApi.Services;
using SchoolApi.Services.Interface;
using SchoolApi.ViewModels;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;
        private readonly IParentRepository _parentRepository;
        public ParentController(IParentService parentService, IParentRepository parentRepository)
        {
            _parentService = parentService;
            _parentRepository = parentRepository;
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ParentVM vm)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try {
                var parentDto = new ParentDto {
                    UserName = vm.UserName,
                    Email = vm.Email,
                    Password = vm.Password, 
                    FullName = vm.FullName, 
                    Address = vm.Address,   
                    PhoneNumber = vm.PhoneNumber,
                };
                await _parentService.Create(parentDto); 
                return Ok("parent created successfully");
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
                var listOfParents = await _parentRepository.GetAllParents();
                var results = listOfParents.Select(x => new
                {
                    x.Id,
                    x.UserName,
                    x.Email,
                    x.FullName,
                    x.Address,
                    x.PhoneNumber,
                    Students = x.ParentStudents!.Select(x => new
                    {
                        x.Student!.Id,
                        x.Student.FullName,
                    })
                });
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
