using Estacionamento.App.Repositorio;
using Estacionamento.App.Services;
using Estacionamento.Contracts.Contracts;
using Estacionamento.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace EstacionamentoAPI.Controllers
{
    [RoutePrefix("api/movimentacao")]
    public class MovimentacaoAPIController : ApiController
    {
        private IMovimentacao _movimentacaoRep = new MovimentacaoRep();

        [HttpGet]
        [Route("ticket/{id:int}")]
        public async Task<MovimentacaoResponse> GetTicket(int id) 
        {
            return _movimentacaoRep.GetTicket(id);
        }

        [HttpGet]
        [Route("placa/{placa}")]
        public async Task<MovimentacaoResponse> GetTicketByPlaca(string placa)
        {
            return _movimentacaoRep.GetTicketByPlaca(placa);
        }

        [HttpPost]
        [Route("lancar-entrada")]
        public async Task<SimpleResponse> LancarEntrada(MovimentacaoRequest request)
        {
            return _movimentacaoRep.LancarEntrada(request);
        }

        [HttpPost]
        [Route("baixar/{id:int}")]
        public async Task<SimpleResponse> LancarBaixaSaida(int id)
        {
            return _movimentacaoRep.LancarBaixaSaida(id);
        }

        [HttpPost]
        [Route("baixar/{placa}")]
        public async Task<SimpleResponse> LancarBaixaSaidaByPlaca(string placa)
        {
            return _movimentacaoRep.LancarBaixaSaidaByPlaca(placa);
        }  
    }
}