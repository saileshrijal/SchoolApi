using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Repository.Interface;
using System.Linq.Expressions;

namespace SchoolApi.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        private readonly DbSet<T> _dbset;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetById(int id) {
            return await _dbset.FindAsync(id)?? throw new Exception("Not found");
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.AsNoTracking().FirstOrDefaultAsync(predicate) ?? throw new Exception("Not found");
        }
    }
}
