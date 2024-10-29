using Netrin.Data.Context;
using Netrin.Domain.Interfaces.Repository;
using Netrin.Domain.Models;

namespace Netrin.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(NetrinDbContext context) : base(context)
        {
        }
    }
}
