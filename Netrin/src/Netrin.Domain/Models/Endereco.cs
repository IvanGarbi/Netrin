namespace Netrin.Domain.Models
{
    public class Endereco : Entity
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public Guid PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}
