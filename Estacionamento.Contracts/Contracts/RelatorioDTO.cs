using Estacionamento.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Contracts.Contracts
{
    public class SumarioRequest 
    {
        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public int EstabelecimentoID { get; set; }
    }

    public class SumarioResponse
    {
        public int EstabelecimentoID { get; set; }

        public DateTime Data { get; set; }

        public int Tipo { get; set; }

        public int Qtde { get; set; }
    }

    public class SumarioPorHoraResponse
    {
        public int EstabelecimentoID { get; set; }

        public DateTime Data { get; set; }

        public TimeSpan Horario { get; set; }

        public int Tipo { get; set; }

        public int Qtde { get; set; }
    }
}