using SchoolApi.Dtos;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;
using SchoolApi.Services.Interface;

namespace SchoolApi.Services
{
    public class ExamSubjectService : IExamSubjectService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGradeRepository _gradeRepository;
        private readonly ISubjectRepository _subjectRepository;
 
        public ExamSubjectService(IUnitOfWork unitOfWork, IGradeRepository gradeRepository, ISubjectRepository subjectRepository)
        {
            _unitOfWork = unitOfWork;  
            _gradeRepository = gradeRepository; 
            _subjectRepository = subjectRepository; 

        }
        public async Task CreateAsync(ExamSubjectDto examSubjectDto)
        {
            var grade = _gradeRepository.GetById(examSubjectDto.GradeId);
            var subject = _subjectRepository.GetById(examSubjectDto.SubjectId);

            if(grade == null) {
                throw new Exception("grade is not available");
            }
            if (subject == null)
            {
                throw new Exception(" subject is not available");
            }
            var examSubject = new SubjectGrade
            {
                GradeId = examSubjectDto.GradeId,
                SubjectId = examSubjectDto.SubjectId,
                FinalTheoryFullMarks = examSubjectDto.FinalTheoryFullMarks,
                FinalPracticalFullMarks = examSubjectDto.FinalPracticalFullMarks
            };

            await _unitOfWork.CommitAsync();
        }
    }
}
