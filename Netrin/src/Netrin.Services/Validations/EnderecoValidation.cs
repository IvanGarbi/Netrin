using FluentValidation;
using Netrin.Domain.Models;

namespace Netrin.Services.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(e => e.Rua)
                .NotNull()
                .NotEmpty().WithMessage("A rua é obrigatória.")
                .MaximumLength(100).WithMessage("A rua deve ter no máximo 100 caracteres.");

            RuleFor(e => e.Numero)
                .NotNull()
                .GreaterThan(0).WithMessage("O número deve ser maior que zero.");

            RuleFor(e => e.Cidade)
                .NotNull()
                .NotEmpty().WithMessage("A cidade é obrigatória.")
                .MaximumLength(50).WithMessage("A cidade deve ter no máximo 50 caracteres.");

            RuleFor(e => e.Estado)
                .NotNull()
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .Length(2).WithMessage("O estado deve ter 2 caracteres.");

            RuleFor(e => e.CEP)
                .NotNull()
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .Length(8).WithMessage("O CEP deveter 8 caracteres.");
        }
    }
}
