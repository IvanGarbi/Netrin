using Netrin.Domain.Models;

namespace Netrin.Domain.Interfaces.Services
{
    public interface IUsuarioService : IDisposable//IBaseService<Usuario>
    {
        Task Create(Usuario entity);
        //Task Update(Endereco entity);
        //Task Delete(Guid id);
    }
}
