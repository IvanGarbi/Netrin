using Netrin.Domain.Models;

namespace Netrin.Domain.Interfaces.Services
{
    public interface IEnderecoService : IDisposable//IBaseService<Endereco>
    {
        Task Create(Endereco entity);
        Task Update(Endereco entity);
        Task Delete(Guid id);
    }
}
