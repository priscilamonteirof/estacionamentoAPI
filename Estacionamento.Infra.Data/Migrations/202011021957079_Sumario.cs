namespace Estacionamento.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sumario : DbMigration
    {
        public override void Up()
        {   
            AddColumn("dbo.Movimentacao", "DataEntrada", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movimentacao", "HoraEntrada", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Movimentacao", "DataSaida", c => c.DateTime());
            AddColumn("dbo.Movimentacao", "HoraSaida", c => c.Time(precision: 7));
            DropColumn("dbo.Movimentacao", "DHEntrada");
            DropColumn("dbo.Movimentacao", "DHSaida");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movimentacao", "DHSaida", c => c.DateTime());
            AddColumn("dbo.Movimentacao", "DHEntrada", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movimentacao", "HoraSaida");
            DropColumn("dbo.Movimentacao", "DataSaida");
            DropColumn("dbo.Movimentacao", "HoraEntrada");
            DropColumn("dbo.Movimentacao", "DataEntrada");
        }
    }
}
