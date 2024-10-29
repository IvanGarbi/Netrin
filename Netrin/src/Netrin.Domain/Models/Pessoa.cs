namespace Netrin.Domain.Models
{
    public class Pessoa : Entity
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public Endereco Endereco { get; set; }
    }
}
