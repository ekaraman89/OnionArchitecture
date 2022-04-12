using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Domain.Entities.Common;
using OnionArchitecture.Persistance.Contexts;
using System.Linq.Expressions;

namespace OnionArchitecture.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly OnionArchitectureDbContext _context;
        public ReadRepository(OnionArchitectureDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query.Where(expression);
        }
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            return await GetSingleAsync(x => x.Id == Guid.Parse(id), tracking);
        }
    }
}
