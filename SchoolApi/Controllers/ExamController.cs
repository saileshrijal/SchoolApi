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
        private readonly IExamTypeRepository _examTypeRepository;
        private readonly IExamTypeService _examTypeService;

        public ExamController(IExamTypeRepository examTypeRepository, IExamTypeService examTypeService)
        {
            _examTypeRepository = examTypeRepository;
            _examTypeService = examTypeService; 
        }

       
    }
}
