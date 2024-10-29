using Netrin.Domain.Models;

namespace Netrin.Domain.Interfaces.Services
{
    public interface IEnderecoService
    {
        Task Create(Endereco entity);
        Task Update(Endereco entity);
        Task Delete(Guid id);
    }
}
