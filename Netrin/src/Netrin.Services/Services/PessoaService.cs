using Netrin.Domain.Interfaces.Notificacoes;
using Netrin.Domain.Interfaces.Repository;
using Netrin.Domain.Interfaces.Services;
using Netrin.Domain.Models;
using Netrin.Services.Validations;

namespace Netrin.Services.Services
{
    public class PessoaService : BaseService, IPessoaService
    {
        private readonly IPessoaRepository _repository;
        public PessoaService(IPessoaRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;
        }

        public async Task Create(Pessoa entity)
        {
            var validation = await Validate(new PessoaValidation(), entity);

            if (!validation)
            {
                return;
            }

            await _repository.Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var pessoaDb = await _repository.GetById(id);

            if (pessoaDb == null)
            {
                _notificador.AddNotificacao("Pessoa não encontrada.");

                return;
            }

            await _repository.Delete(id);
        }

        public async Task Update(Pessoa entity)
        {
            var validation = await Validate(new PessoaValidation(), entity);

            if (!validation)
            {
                return;
            }

            var pessoaDb = await _repository.GetById(entity.Id);

            if (pessoaDb == null)
            {
                _notificador.AddNotificacao("Pessoa não encontrada.");

                return;
            }

            await _repository.Update(entity);
        }
    }
}
