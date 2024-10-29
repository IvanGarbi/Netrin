using Netrin.Domain.Interfaces.Notificacoes;
using Netrin.Domain.Interfaces.Repository;
using Netrin.Domain.Interfaces.Services;
using Netrin.Domain.Models;
using Netrin.Services.Validations;

namespace Netrin.Services.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;
        }

        public async Task Create(Usuario entity)
        {
            var validation = await Validate(new UsuarioValidation(), entity);

            if (!validation)
            {
                return;
            }

            await _repository.Create(entity);
        }
    }
}
