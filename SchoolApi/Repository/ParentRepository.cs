using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;
using SchoolApi.Repository.Interface;

namespace SchoolApi.Repository
{
    public class ParentRepository:Repository<Parent>, IParentRepository
    {
        public ParentRepository(ApplicationDbContext context):base(context)
        {
            
        }

        public async Task<List<Parent>> GetAllParents()
        {
            return await _context.Parents!
                                .Include(x=>x.ParentStudents)!
                                .ThenInclude(x=>x.Student)
                                .ToListAsync();
        }

        public async Task<bool> IsAnyById(string id)
        {
            return await _context.Parents!.AnyAsync(x => x.Id == id);
        }

    }
}
