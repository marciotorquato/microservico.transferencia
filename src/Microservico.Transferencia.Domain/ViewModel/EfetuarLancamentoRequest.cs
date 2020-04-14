namespace Microservico.Transferencia.Domain.ViewModel
{
    public class EfetuarLancamentoRequest
    {
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public double Valor { get; set; }
    }
}