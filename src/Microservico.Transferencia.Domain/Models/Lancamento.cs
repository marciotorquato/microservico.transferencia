using System;

namespace Microservico.Transferencia.Domain.Models
{
    public class Lancamento
    {
        public Lancamento()
        {
            Id = Guid.NewGuid();
            DataLancamento = DateTime.Now;
        }

        public Guid Id { get; set; }
        public double Valor { get; set; }
        public DateTime DataLancamento { get; set; }

        // Relacionamento
        public ContaCorrente ContaOrigem { get; set; }
        public ContaCorrente ContaDestino { get; set; }
    }
}

// TESTE