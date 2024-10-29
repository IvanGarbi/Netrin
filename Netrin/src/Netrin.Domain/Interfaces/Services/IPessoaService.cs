using Netrin.Domain.Models;

namespace Netrin.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        Task Create(Pessoa entity);
        Task Update(Pessoa entity);
        Task Delete(Guid id);
    }
}
