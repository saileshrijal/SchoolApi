namespace School.Data.IRepository
{
    public interface IUnitOfWork
    {
        IGradeRepository Grade { get; }
        Task<int> SaveAsync();
    }
}
