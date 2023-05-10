using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;
using SchoolApi.Services.Interface;

namespace SchoolApi.Services
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;   
        private readonly IExamRepository _examRepository;

        public ExamService(IUnitOfWork unitOfWork, IExamRepository examRepository)
        {
            _unitOfWork = unitOfWork;  
            _examRepository = examRepository;
        }
        public async Task CreateAsync(ExamDto examDto)
        {
            var examType = await _examRepository.IsAnyById(examDto.ExamTypeId);
            if (!examType)
            {
                throw new Exception("exam type not present");
            }
            var exam = new Exam {
                Name = examDto.Name,
                ExamTypeId = examDto.ExamTypeId,
                AttendanceFrom = examDto.AttendanceFrom,
                AttendanceTo = examDto.AttendanceTo,
                SchoolDays = examDto.SchoolDays,
                ResultActive = examDto.ResultActive,    
            };

            await _unitOfWork.CreateAsync(exam);
            await _unitOfWork.CommitAsync();
        }
    }
}
