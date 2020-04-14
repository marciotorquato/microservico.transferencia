using Microservico.Transferencia.Domain;
using Microservico.Transferencia.Domain.Interfaces.Repository;
using Microservico.Transferencia.Domain.Models;
using Microservico.Transferencia.Domain.ViewModel;
using System;

namespace Microservico.Transferencia.Service.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoService(IContaCorrenteRepository contaCorrenteRepository, ILancamentoRepository lancamentoRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _lancamentoRepository = lancamentoRepository;
        }

        /// <summary>
        /// Serviço responsavel por efetuar o lançamento.
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns></returns>
        public int EfetuarLancamento(EfetuarLancamentoRequest lancamento)
        {
            try
            {
                // Verificar se a conta origem e destino são iguais ou valor de lançamento ser zerado
                if (lancamento.ContaOrigem == lancamento.ContaDestino || lancamento.Valor == 0.00) 
                    return 400;                

                // Buscar informações da conta de origem
                ContaCorrente contaOrigem = _contaCorrenteRepository.Buscar(lancamento.ContaOrigem);

                // Buscar informações da conta de destino
                ContaCorrente contaDestino = _contaCorrenteRepository.Buscar(lancamento.ContaDestino);

                // Verifica se as contas existem
                if (contaOrigem == null || contaDestino == null)
                    return 400;

                //Validar se a conta origem possui saldo para fazer a transferencia
                if (contaOrigem.Saldo < lancamento.Valor)
                    return 400;

                // Desconta o valor do lançamento da conta Origem
                contaOrigem.Saldo -= lancamento.Valor;

                // Incrementa o valor do lançamento na conta Destino
                contaDestino.Saldo += lancamento.Valor;

                Lancamento l = new Lancamento();
                l.Valor = lancamento.Valor;
                l.ContaOrigem = contaOrigem;
                l.ContaDestino = contaDestino;

                // responsavel por fazer a inserção na tabela 
                _lancamentoRepository.FazerLancamento(l);

                return 200;
            }
            catch (Exception ex){
                return 400;
            }
        }
    }
}