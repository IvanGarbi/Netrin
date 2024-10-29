using Netrin.Data.Context;
using Netrin.Domain.Interfaces.Repository;
using Netrin.Domain.Models;

namespace Netrin.Data.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(NetrinDbContext context) : base(context)
        {
        }
    }
}
