using Estacionamento.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Domain.Entities
{
    public class Veiculo
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public int ModeloID { get; set; }
        public virtual Modelo Modelo { get; set; }

        [Required]
        public ECor Cor { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public ETipoVeiculo Tipo { get; set; }        

        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }
    }
}