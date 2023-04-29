using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;
using SchoolApi.Services.Interface;

namespace SchoolApi.Services
{
    public class GradeService: IGradeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGradeRepository _gradeRepository; 
        public GradeService(IUnitOfWork unitOfWork, IGradeRepository gradeRepository)
        {
            _unitOfWork = unitOfWork;
            _gradeRepository = gradeRepository;
        }

        public async Task CreateAsync(GradeDto gradeDto)
        {
            var grade = new Grade {
                Name = gradeDto.Name,
                Description = gradeDto.Description,
                CreatedAt = DateTime.Now,
            };
            await _unitOfWork.CreateAsync(grade);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var grade = await _gradeRepository.GetById(id);
            await _unitOfWork.DeleteAsync(grade);
            await _unitOfWork.CommitAsync();    
        }

        public async Task UpdateAsync(int id, GradeDto gradeDto)
        {
            var grade = await _gradeRepository.GetById(id);
            grade.Name = gradeDto.Name; 
            grade.Description = gradeDto.Description;
            await _unitOfWork.CommitAsync();
        }

        public async Task AssignSubjectsToGrade(int gradeId, List<int> subjectIds) {
            var grade = await _gradeRepository.GetGradeWithSubjects(gradeId);

            grade.SubjectGrades = subjectIds.Select(x => new SubjectGrade
            {
                SubjectId = x,
                GradeId = gradeId
            }).ToList();

            await _unitOfWork.CommitAsync();
        }
    }
}
