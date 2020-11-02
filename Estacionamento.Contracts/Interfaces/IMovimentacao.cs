using Estacionamento.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Contracts.Interfaces
{
    public interface IMovimentacao
    {
        MovimentacaoResponse GetTicket(int id);
        MovimentacaoResponse GetTicketByPlaca(string placa);
        SimpleResponse LancarEntrada(MovimentacaoRequest request);
        SimpleResponse LancarBaixaSaida(int id);
        SimpleResponse LancarBaixaSaidaByPlaca(string placa); 
    }
}
