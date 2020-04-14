using Microservico.Transferencia.Domain.Interfaces.Repository;
using Microservico.Transferencia.Domain.Models;
using System;

namespace Microservico.Transferencia.Test
{
    public class LancamentoRepositoryMock : ILancamentoRepository
    {
        // Conta que irá causar um exceção na hora de fazer a inserção e atualização dos dados
        private readonly int contaInvalida = 4;

        public void FazerLancamento(Lancamento lancamento)
        {
            if (lancamento.ContaOrigem.Id == contaInvalida) {
                throw new Exception("erro ao inserir lancamento");
            }
        }
    }
}