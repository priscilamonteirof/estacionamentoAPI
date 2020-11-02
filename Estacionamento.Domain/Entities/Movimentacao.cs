using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Domain.Entities
{
    public class Movimentacao
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int EstabelecimentoID { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }

        [Required]
        public int VeiculoID { get; set; }
        public virtual Veiculo Veiculo { get; set; }

        [Required]
        public DateTime DataEntrada { get; set; }
        public TimeSpan HoraEntrada { get; set; }

        public DateTime? DataSaida { get; set; }
        public TimeSpan? HoraSaida { get; set; }

        public TimeSpan TempoPermanencia
        {
            get { return (this.DataSaida.HasValue ? this.DataSaida.Value + this.HoraSaida.Value : DateTime.Now) - (this.DataEntrada + this.HoraEntrada); }
        }
    }
}