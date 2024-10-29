using System.ComponentModel.DataAnnotations;

namespace Netrin.App.Models
{
    public class PessoaViewModel
    {
        [Required(ErrorMessage = "O Nome Completo é obrigatório")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string CPF { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public EnderecoViewModel EnderecoViewModel { get; set; }
    }

    public class GetPessoaViewModel
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public EnderecoViewModel EnderecoViewModel { get; set; }
    }
}
