using FluentValidation;
using Netrin.Domain.Models;

namespace Netrin.Services.Validations
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(p => p.NomeCompleto)
                .NotNull()
                .NotEmpty().WithMessage("O nome completo é obrigatório.")
                .MinimumLength(3).WithMessage("O nome completo deve ter pelo menos 3 caracteres.")
                .MaximumLength(100).WithMessage("O nome completo deve ter no máximo 100 caracteres.");

            RuleFor(p => p.DataNascimento)
                .NotEmpty()
                .NotNull().WithMessage("A data de nascimento é obrigatória.")
                .Must(BeAValidAge).WithMessage("Essa data de nascimento é inválida.");

            RuleFor(p => p.CPF)
                .NotNull()
                .NotEmpty()
                .WithMessage("O CPF deve ser informado.")
                .Matches("^[0-9]+$")
                .WithMessage("O {PropertyName} deve conter somente números.")
                .MinimumLength(11)
                .MaximumLength(11)
                .WithMessage("O {PropertyName} deve ter 11 caracteres.")
                .Must(cpf => ValidarCpf(cpf))
                .WithMessage("O {PropertyName} não está em formato de CPF adequado.");
            
            RuleFor(p => p.Telefone)
                .Matches(@"^\d+$").When(s => !string.IsNullOrEmpty(s.Telefone)).WithMessage("O telefone deve conter apenas números.")
                .Length(8, 20).When(s => !string.IsNullOrEmpty(s.Telefone)).WithMessage("O telefone deve ter entre 8 e 20 caracteres.");

            RuleFor(p => p.Email)
                .EmailAddress().When(s => !string.IsNullOrEmpty(s.Email)).WithMessage("E-mail inválido.")
                .MaximumLength(100).When(s => !string.IsNullOrEmpty(s.Email)).WithMessage("O email deve ter no máximo 100 caracteres.");

            RuleFor(p => p.Endereco)
                .SetValidator(new EnderecoValidation()).When(e => e.Endereco != null);
        }

        private bool BeAValidAge(DateTime date)
        {
            if (date >= DateTime.Today)
            {
                return false;
            }
            return true;
        }

        private static bool ValidarCpf(string cpf)
        {
            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}
