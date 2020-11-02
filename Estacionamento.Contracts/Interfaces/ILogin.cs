using Estacionamento.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Contracts.Interfaces
{
    public interface ILogin
    {
        LoginResponse Login(LoginRequest request);
    }
}
