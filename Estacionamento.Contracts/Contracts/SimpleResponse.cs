using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Estacionamento.Contracts.Contracts
{
    public class SimpleResponse
    {
        public int ID { get; set; }

        [DefaultValue("false")]
        public bool Error { get; set; }

        [DefaultValue("")]
        public string ErrorMessage { get; set; }
    }
}