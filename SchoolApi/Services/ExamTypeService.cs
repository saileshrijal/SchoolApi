using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;
using SchoolApi.Services.Interface;

namespace SchoolApi.Services
{
    public class ExamTypeService : IExamTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExamTypeRepository _examTypeRepository;

        public ExamTypeService(IUnitOfWork unitOfWork, IExamTypeRepository examTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _examTypeRepository = examTypeRepository;   
        }
        public async Task CreateAsync(ExamTypeDto examTypeDto)
        {
            var examType = new ExamType {
                Name = examTypeDto.Name,    
                CreatedDate = DateTime.Now
            };
            await _unitOfWork.CreateAsync(examType);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, ExamTypeDto examTypeDto) {
            var examType = await _examTypeRepository.GetById(id);
            examType.Name = examTypeDto.Name;
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var examType = await _examTypeRepository.GetById(id);
            await _unitOfWork.DeleteAsync(examType);
            await _unitOfWork.CommitAsync();    
        }
    }
}
