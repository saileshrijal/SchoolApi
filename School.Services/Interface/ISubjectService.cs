
using School.Models;

namespace School.Services.Interface
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAll();
        Task<Subject> Get(int id); 
        Task<int> Delete(int id);
        Task<int> Edit(Subject subject);
        Task<int> Create(Subject subject);  

    }
}
