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
    [RoutePrefix("api/login")]
    public class AutenticacaoAPIController : ApiController
    {
        private ILogin _loginRep = new LoginRep();

        [HttpGet]
        [Route("")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return _loginRep.Login(request);
        }
    }
}