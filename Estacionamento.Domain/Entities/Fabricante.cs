using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Domain.Entities
{
    public class Fabricante
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}