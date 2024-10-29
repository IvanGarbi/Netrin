using FluentValidation;
using Netrin.Domain.Interfaces.Notificacoes;
using Netrin.Domain.Models;

namespace Netrin.Services.Services
{
    public abstract class BaseService
    {
        protected readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected async Task<bool> Validate<TV, TE>(TV validator, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validacao = await validator.ValidateAsync(entidade);

            if (validacao.IsValid)
            {
                return true;
            }

            foreach (var error in validacao.Errors)
            {
                _notificador.AddNotificacao(error.ErrorMessage);
            }

            return false;
        }

    }
}
