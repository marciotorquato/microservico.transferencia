using Microservico.Transferencia.Domain.Interfaces.Repository;
using Microservico.Transferencia.Domain.Models;
using Microservico.Transferencia.Repository.Context;

namespace Microservico.Transferencia.Repository.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly TransferenciaContext _context;

        public LancamentoRepository(TransferenciaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Responsavel por fazer a atualização dos dados na tabela ContaCorrentes e 
        /// inserir os dados na tabela Lancamentos
        /// </summary>
        /// <param name="lancamento"></param>
        public void FazerLancamento(Lancamento lancamento)
        {
            _context.Lancamentos.Add(lancamento);
            _context.SaveChanges();            
        }
    }
}