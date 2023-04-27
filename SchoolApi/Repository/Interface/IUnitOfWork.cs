namespace SchoolApi.Repository.Interface
{
    public interface IUnitOfWork
    {
        Task CreateAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T: class;
        Task DeleteAsync<T>(T entity) where T : class;

        //save
        Task<int> CommitAsync();
    }
}
