using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Contracts.Contracts
{
    public class EstabelecimentoRequest
    {
        public int ID { get; set; }

        public string Nome { get; set; }
        
        public string CNPJ { get; set; }

        public string Endereco { get; set; }
        
        public string Telefone { get; set; }

        public int QtdeMoto { get; set; }
        
        public int QtdeCarro { get; set; }
    }

    public class EstabelecimentoResponse : SimpleResponse
    {
        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public int QtdeMoto { get; set; }

        public int QtdeCarro { get; set; }
    }
}