namespace Estacionamento.Infra.Data.Migrations
{
    using Estacionamento.Domain.Entities;
    using Estacionamento.Infra.Data.Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contexto context)
        {           
            context.Fabricantes.AddOrUpdate(
                f => f.ID,
                new Fabricante { Nome = "VW" },
                new Fabricante { Nome = "Fiat" },
                new Fabricante { Nome = "GM" },
                new Fabricante { Nome = "Ford" },
                new Fabricante { Nome = "Hyundai" },
                new Fabricante { Nome = "Citroen" },
                new Fabricante { Nome = "Peugeot" },
                new Fabricante { Nome = "Nissan" },
                new Fabricante { Nome = "Toyota" },
                new Fabricante { Nome = "Honda" }
            );

            context.Modelos.AddOrUpdate(
                f => f.ID,
                new Modelo { MarcaID = 1, Nome = "Polo" },
                new Modelo { MarcaID = 2, Nome = "Argo" },
                new Modelo { MarcaID = 3, Nome = "Onix" },
                new Modelo { MarcaID = 4, Nome = "Fiesta" },
                new Modelo { MarcaID = 5, Nome = "I30" },
                new Modelo { MarcaID = 6, Nome = "C3" },
                new Modelo { MarcaID = 7, Nome = "308" },
                new Modelo { MarcaID = 8, Nome = "March" },
                new Modelo { MarcaID = 9, Nome = "Corolla" },
                new Modelo { MarcaID = 10, Nome = "Fit" }
            );
        }
    }
}
