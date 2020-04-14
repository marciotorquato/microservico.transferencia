using Microservico.Transferencia.Domain.Models;

namespace Microservico.Transferencia.Domain.Interfaces.Repository
{
    public interface IContaCorrenteRepository
    {
        ContaCorrente Buscar(int numeroConta);
    }
}
