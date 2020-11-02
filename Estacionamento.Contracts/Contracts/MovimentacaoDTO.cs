using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estacionamento.Contracts.Contracts
{
    public class MovimentacaoRequest
    {
        public int EstabelecimentoID { get; set; }

        public string Placa { get; set; }
    }

    public class MovimentacaoResponse : SimpleResponse
    {
        public int VeiculoID { get; set; }

        public string Placa { get; set; }

        public DateTime DataEntrada { get; set; }

        public TimeSpan HoraEntrada { get; set; }

        public DateTime? DataSaida { get; set; }

        public TimeSpan? HoraSaida { get; set; }
    }
}