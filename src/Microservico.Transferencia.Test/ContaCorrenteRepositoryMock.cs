using Microservico.Transferencia.Domain.Interfaces.Repository;
using Microservico.Transferencia.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microservico.Transferencia.Test
{
    public class ContaCorrenteRepositoryMock : IContaCorrenteRepository
    {
        // Mock de lista de Conta Correntes
        private readonly List<ContaCorrente> ListaContaCorrenteMock = new List<ContaCorrente>() {
            new ContaCorrente(){ Id = 1, Saldo = 0.00 },
            new ContaCorrente(){ Id = 2, Saldo = 1500.00 },
            new ContaCorrente(){ Id = 3, Saldo = 1000.00 },
            new ContaCorrente(){ Id = 4, Saldo = 2000.00 },
            new ContaCorrente(){ Id = 5, Saldo = 10000.00 },
        };

        public ContaCorrente Buscar(int numeroConta)
        {
            return ListaContaCorrenteMock.FirstOrDefault(c => c.Id == numeroConta);
        }
    }
}