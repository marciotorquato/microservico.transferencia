using Microservico.Transferencia.Domain.Interfaces.Repository;
using Microservico.Transferencia.Domain.Models;
using Microservico.Transferencia.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Microservico.Transferencia.Repository.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly TransferenciaContext _context;

        public ContaCorrenteRepository(TransferenciaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Responsavel por buscar a ContaCorrente pelo Id => Numero da Conta
        /// </summary>
        /// <param name="numeroConta"></param>
        /// <returns></returns>
        public ContaCorrente Buscar(int numeroConta)
        {
            return _context.ContaCorrentes.FirstOrDefault(c => c.Id == numeroConta);
        }
    }
}