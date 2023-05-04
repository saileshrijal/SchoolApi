using SchoolApi.Models;

namespace SchoolApi.Repository.Interface
{
    public interface IParentRepository:IRepository<Parent>
    {
        Task<bool> IsAnyById(string id);
        Task<List<Parent>> GetAllParents();
    }
}
