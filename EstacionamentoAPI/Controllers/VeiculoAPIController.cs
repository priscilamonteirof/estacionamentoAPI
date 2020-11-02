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
    [RoutePrefix("api/veiculos")]
    public class VeiculoAPIController : ApiController
    {
        private IVeiculo _veiculoRep = new VeiculoRep();

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<VeiculoResponse>> GetAll()
        {
            return _veiculoRep.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<VeiculoResponse> Get(int id)
        {
            return _veiculoRep.Get(id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<SimpleResponse> Save(VeiculoRequest request)
        {
            return _veiculoRep.Save(request);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<SimpleResponse> Delete(int id)
        {
            return _veiculoRep.Delete(id);
        }    
    }
}