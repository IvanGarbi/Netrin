using Netrin.Domain.Interfaces.Notificacoes;
using Netrin.Domain.Notificacoes;

namespace Netrin.Services.Notificacoes
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacaoList;

        public Notificador()
        {
            _notificacaoList = new List<Notificacao>();
        }

        public void AddNotificacao(string mensagem)
        {
            _notificacaoList.Add(new Notificacao(mensagem));
        }

        public IEnumerable<Notificacao> RetornarNotificacao()
        {
            return _notificacaoList;
        }

        public bool TemNotificacao()
        {
            return _notificacaoList.Any();
        }
    }
}
