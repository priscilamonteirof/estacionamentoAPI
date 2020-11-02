using Estacionamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Estacionamento.Infra.Data.Context
{
    public class Contexto: DbContext
    {
        public Contexto()
            : base("ConexaoBD")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<Contexto>(null);
        }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }        
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}