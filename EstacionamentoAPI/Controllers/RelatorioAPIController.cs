using Estacionamento.App.Services;
using Estacionamento.Contracts.Contracts;
using Estacionamento.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EstacionamentoAPI.Controllers
{
    [RoutePrefix("api/relatorios")]
    public class RelatorioAPIController : ApiController
    {
        private IRelatorio _reltorioRep = new RelatorioRep();

        [HttpGet]
        [Route("sumario")]
        public async Task<IEnumerable<SumarioResponse>> GetSumario(SumarioRequest request)
        {
            return _reltorioRep.GetSumario(request);
        }

        [HttpGet]
        [Route("sumario-por-hora")]
        public async Task<IEnumerable<SumarioPorHoraResponse>> GetSumarioPorHora(SumarioRequest request)
        {
            return _reltorioRep.GetSumarioPorHora(request);
        }
    }
}