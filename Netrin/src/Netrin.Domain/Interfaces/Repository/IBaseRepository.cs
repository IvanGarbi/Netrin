using Netrin.Domain.Models;

namespace Netrin.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TE> : IDisposable where TE : Entity
    {
        Task Create(TE entity);
        Task Update(TE entity);
        Task Delete(Guid id);
        Task<TE> GetById(Guid id);
        Task<IEnumerable<TE>> Get();
        Task<int> SaveChanges();
    }
}
