using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;
using SchoolApi.Services.Interface;

namespace SchoolApi.Services
{
    public class SubjectService:ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(IUnitOfWork unitOfWork, ISubjectRepository subjectRepository)
        {
            _unitOfWork = unitOfWork;
            _subjectRepository = subjectRepository;
        }

        public async Task CreateAsync(SubjectDto subjectDto)
        {
            var subject = new Subject
            {
                Name = subjectDto.Name,
                Code = subjectDto.Code,
                Description = subjectDto.Description,
            };
            await _unitOfWork.CreateAsync(subject);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subject = await _subjectRepository.GetById(id);
            await _unitOfWork.DeleteAsync(subject);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int id, SubjectDto subjectDto)
        {
            var subject = await _subjectRepository.GetById(id);
            subject.Name = subjectDto.Name;
            subject.Code = subjectDto.Code;
            subject.Description = subjectDto.Description;
            await _unitOfWork.CommitAsync();
        }
    }
}
