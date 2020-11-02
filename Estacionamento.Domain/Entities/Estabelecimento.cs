using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estacionamento.Domain.Entities
{
    public class Estabelecimento
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string CNPJ { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(150)]
        public string Endereco { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telefone { get; set; }

        [Required]
        public int QuantidadeVagaMoto { get; set; }

        [Required]
        public int QuantidadeVagaCarro { get; set; }
    }
}