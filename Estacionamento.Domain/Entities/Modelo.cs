using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Domain.Entities
{
    public class Modelo
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int MarcaID { get; set; }
        public virtual Fabricante Marca { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}