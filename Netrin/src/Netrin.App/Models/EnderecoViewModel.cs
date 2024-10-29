namespace Netrin.App.Models
{
    public class EnderecoViewModel
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public Guid PessoaId { get; set; }

        public PessoaViewModel PessoaViewModel { get; set; }
    }
}
