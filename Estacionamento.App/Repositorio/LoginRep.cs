using Estacionamento.Contracts.Contracts;
using Estacionamento.Contracts.Interfaces;
using Estacionamento.CrossCutting.Enum;
using Estacionamento.Domain.Entities;
using Estacionamento.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Estacionamento.App.Services
{
    public class LoginRep : ILogin
    {
        private Contexto _ctx;

        public LoginRep()
        {
            this._ctx = new Contexto();
        }

        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            try
            {
                var login = _ctx.Usuarios
                            .Where(e => e.Login == request.Login && e.Password == request.Password)
                            .FirstOrDefault();

                response.IsAthenticated = (login == null ? false : true);
            }
            catch (Exception ex)
            {
                response.IsAthenticated = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}