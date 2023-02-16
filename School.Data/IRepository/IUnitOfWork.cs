namespace School.Data.IRepository
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}
