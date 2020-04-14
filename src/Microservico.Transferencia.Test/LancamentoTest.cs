using Xunit;
using Microservico.Transferencia.Service.Services;
using Microservico.Transferencia.Domain.ViewModel;

namespace Microservico.Transferencia.Test
{
    public class LancamentoTest
    {
        private readonly ContaCorrenteRepositoryMock _contaCorrenteRepositoryMock = new ContaCorrenteRepositoryMock();
        private readonly LancamentoRepositoryMock _lancamentoRepositoryMock = new LancamentoRepositoryMock();
        private readonly LancamentoService _service;

        public LancamentoTest()
        {
            _service = new LancamentoService(_contaCorrenteRepositoryMock, _lancamentoRepositoryMock);
        }

        [Fact]
        public void EfetuarLancamentoContaOrigemSemSaldo()
        {
            var result = _service.EfetuarLancamento(new EfetuarLancamentoRequest() { ContaOrigem = 1, ContaDestino = 2, Valor = 100.00 });
            Assert.Equal(400, result);
        }

        [Fact]
        public void EfetuarLancamentoContaOrigemDestinoIguais()
        {
            var result = _service.EfetuarLancamento(new EfetuarLancamentoRequest() { ContaOrigem = 2, ContaDestino = 2, Valor = 500.00 });
            Assert.Equal(400, result);
        }

        [Fact]
        public void EfetuarLancamentoComValorZerado()
        {
            var result = _service.EfetuarLancamento(new EfetuarLancamentoRequest() { ContaOrigem = 2, ContaDestino = 3, Valor = 0.00 });
            Assert.Equal(400, result);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void EfetuarLancamentoContaOrigemNaoExiste(int contaOrigem)
        {
            var result = _service.EfetuarLancamento(new EfetuarLancamentoRequest() { ContaOrigem = contaOrigem, ContaDestino = 2, Valor = 300.00 });
            Assert.Equal(400, result);
        }


        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void EfetuarLancamentoContaDestinoNaoExiste(int contaDestino)
        {
            var result = _service.EfetuarLancamento(new EfetuarLancamentoRequest() { ContaOrigem = 2, ContaDestino = contaDestino, Valor = 400.00 });
            Assert.Equal(400, result);
        }

        [Fact]
        public void EfetuarLancamentoErroAoGravarBanco()
        {
            var result = _service.EfetuarLancamento(new EfetuarLancamentoRequest() { ContaOrigem = 4, ContaDestino = 7, Valor = 400.00 });
            Assert.Equal(400, result);
        }

        [Theory]
        [InlineData(2, 3, 500.00)]
        [InlineData(3, 2, 100.00)]
        [InlineData(3, 5, 350.00)]
        [InlineData(5, 2, 600.00)]
        public void EfetuarLancamentoComSucesso(int contaOrigem, int contaDestino, double valor)
        {
            var result = _service.EfetuarLancamento(new EfetuarLancamentoRequest()
            {
                ContaOrigem = contaOrigem,
                ContaDestino = contaDestino,
                Valor = valor
            });

            Assert.Equal(200, result);
        }
    }
}