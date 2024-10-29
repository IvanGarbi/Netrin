using Microsoft.EntityFrameworkCore;
using Netrin.Data.Context;
using Netrin.Domain.Interfaces.Repository;
using Netrin.Domain.Models;

namespace Netrin.Data.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(NetrinDbContext context) : base(context)
        {
        }

        public override async Task<Pessoa> GetById(Guid id)
        {
            return await _dbSet.AsNoTracking()
                              .Include(z => z.Endereco)
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
