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
    [RoutePrefix("api/estabelecimentos")]
    public class EstabelecimentoAPIController : ApiController
    {
        private IEstabelecimento _estabelecimentoRep = new EstabelecimentoRep();

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<EstabelecimentoResponse>> GetAll()
        {
            return _estabelecimentoRep.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<EstabelecimentoResponse> Get(int id)
        {
            return _estabelecimentoRep.Get(id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<SimpleResponse> Save(EstabelecimentoRequest request)
        {
            return _estabelecimentoRep.Save(request);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<SimpleResponse> Delete(int id)
        {
            return _estabelecimentoRep.Delete(id);
        }        
    }
}