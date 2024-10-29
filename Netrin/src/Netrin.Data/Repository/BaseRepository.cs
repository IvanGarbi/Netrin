using Microsoft.EntityFrameworkCore;
using Netrin.Data.Context;
using Netrin.Domain.Interfaces.Repository;
using Netrin.Domain.Models;

namespace Netrin.Data.Repository
{
    public class BaseRepository<TE> : IBaseRepository<TE> where TE : Entity, new()
    {
        protected readonly NetrinDbContext _context;
        protected readonly DbSet<TE> _dbSet;

        public BaseRepository(NetrinDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TE>();
        }

        public async Task Create(TE entity)
        {
            _context.Add(entity);
            await SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            _context.Remove(new TE { Id = id });
            await SaveChanges();
        }

        public async void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IEnumerable<TE>> Get()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TE> GetById(Guid id)
        {
            return await _dbSet.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task Update(TE entity)
        {
            _context.Update(entity);
            await SaveChanges();
        }
    }
}
