using Estacionamento.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Contracts.Contracts
{
    public class LoginRequest 
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public bool IsAthenticated { get; set; }

        public string ErrorMessage { get; set; }
    }
}