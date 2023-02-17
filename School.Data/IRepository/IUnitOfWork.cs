namespace School.Data.IRepository
{
    public interface IUnitOfWork
    {
        IGradeRepository Grade { get; }
        ISubjectRepository Subject { get; }
        Task<int> SaveAsync();
    }
}
