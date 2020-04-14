using Microservico.Transferencia.Domain;
using Microservico.Transferencia.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Microservico.Transferencia.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/lancamento")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoService _lancamentoService;

        public LancamentoController(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        /// <summary>
        /// Metodo responsavel por fazer o lançamento do valor de uma conta para outra
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<string> Post([FromBody] EfetuarLancamentoRequest lancamento)
        {
            var result = _lancamentoService.EfetuarLancamento(lancamento);
            return StatusCode(result);
        }
    }
}