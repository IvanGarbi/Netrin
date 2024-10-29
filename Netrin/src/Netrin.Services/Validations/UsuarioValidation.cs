using FluentValidation;
using Netrin.Domain.Models;

namespace Netrin.Services.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(p => p.Nome)
                .NotNull()
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 caracteres.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(p => p.Email)
                .NotNull()
                .NotEmpty().WithMessage("O Email é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.")
                .MaximumLength(100).WithMessage("O email deve ter no máximo 100 caracteres.");
        }
    }
}
