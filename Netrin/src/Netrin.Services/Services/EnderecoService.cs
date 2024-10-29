using Netrin.Domain.Interfaces.Notificacoes;
using Netrin.Domain.Interfaces.Repository;
using Netrin.Domain.Interfaces.Services;
using Netrin.Domain.Models;
using Netrin.Services.Validations;

namespace Netrin.Services.Services
{
    public class EnderecoService : BaseService, IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        public EnderecoService(IEnderecoRepository repository, INotificador notificador) : base(notificador)
        {
            _repository = repository;
        }

        public async Task Create(Endereco entity)
        {
            var validation = await Validate(new EnderecoValidation(), entity);

            if (!validation)
            {
                return;
            }

            var enderecoDb = await _repository.GetById(entity.Id);

            if (enderecoDb == null)
            {
                _notificador.AddNotificacao("Endereço não encontrada.");

                return;
            }

            await _repository.Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var enderecoDb = await _repository.GetById(id);

            if (enderecoDb == null)
            {
                _notificador.AddNotificacao("Endereço não encontrada.");

                return;
            }

            await _repository.Delete(id);
        }

        public async Task Update(Endereco entity)
        {
            var validation = await Validate(new EnderecoValidation(), entity);

            if (!validation)
            {
                return;
            }

            var enderecoDb = await _repository.GetById(entity.Id);

            if (enderecoDb == null)
            {
                _notificador.AddNotificacao("Endereço não encontrada.");

                return;
            }

            await _repository.Update(entity);
        }
    }
}
