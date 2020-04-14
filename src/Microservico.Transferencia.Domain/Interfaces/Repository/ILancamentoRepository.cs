using Microservico.Transferencia.Domain.Models;

namespace Microservico.Transferencia.Domain.Interfaces.Repository
{
    public interface ILancamentoRepository
    {
        void FazerLancamento(Lancamento lancamento);
    }
}
