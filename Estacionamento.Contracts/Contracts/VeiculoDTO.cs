using Estacionamento.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Contracts.Contracts
{
    public class VeiculoRequest
    {
        public int ID { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }

        public string Placa { get; set; }

        public string Tipo { get; set; }
    }

    public class VeiculoResponse : SimpleResponse
    {
        public int ID { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }

        public string Placa { get; set; }

        public string Tipo { get; set; }
    }
}