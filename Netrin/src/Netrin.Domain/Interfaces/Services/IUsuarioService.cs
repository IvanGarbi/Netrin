using Netrin.Domain.Models;

namespace Netrin.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task Create(Usuario entity);
    }
}
