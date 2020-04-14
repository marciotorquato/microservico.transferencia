using Microservico.Transferencia.Domain.ViewModel;

namespace Microservico.Transferencia.Domain
{
    public interface ILancamentoService
    {
        int EfetuarLancamento(EfetuarLancamentoRequest lancamento);
    }
}