using Netrin.Domain.Notificacoes;

namespace Netrin.Domain.Interfaces.Notificacoes
{
    public interface INotificador
    {
        void AddNotificacao(string mensagem);
        bool TemNotificacao();
        IEnumerable<Notificacao> RetornarNotificacao();
    }
}
