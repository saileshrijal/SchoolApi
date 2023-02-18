using School.Data.IRepository;

namespace School.Data.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGradeRepository Grade { get; private set; }
        public ISubjectRepository Subject { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Grade = new GradeRepository(context);
            Subject = new SubjectRepository(context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
