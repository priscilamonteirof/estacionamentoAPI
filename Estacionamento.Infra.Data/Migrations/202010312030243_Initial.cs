namespace Estacionamento.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estabelecimento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CNPJ = c.String(nullable: false, maxLength: 20),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Endereco = c.String(nullable: false, maxLength: 150),
                        Telefone = c.String(nullable: false, maxLength: 20),
                        QuantidadeVagaMoto = c.Int(nullable: false),
                        QuantidadeVagaCarro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fabricante",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Modelo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MarcaID = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Fabricante", t => t.MarcaID, cascadeDelete: true)
                .Index(t => t.MarcaID);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ModeloID = c.Int(nullable: false),
                        Cor = c.Int(nullable: false),
                        Placa = c.String(nullable: false),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Modelo", t => t.ModeloID, cascadeDelete: true)
                .Index(t => t.ModeloID);
            
            CreateTable(
                "dbo.Movimentacao",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EstabelecimentoID = c.Int(nullable: false),
                        VeiculoID = c.Int(nullable: false),
                        DHEntrada = c.DateTime(nullable: false),
                        DHSaida = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estabelecimento", t => t.EstabelecimentoID, cascadeDelete: true)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoID, cascadeDelete: true)
                .Index(t => t.EstabelecimentoID)
                .Index(t => t.VeiculoID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Login);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimentacao", "VeiculoID", "dbo.Veiculo");
            DropForeignKey("dbo.Movimentacao", "EstabelecimentoID", "dbo.Estabelecimento");
            DropForeignKey("dbo.Veiculo", "ModeloID", "dbo.Modelo");
            DropForeignKey("dbo.Modelo", "MarcaID", "dbo.Fabricante");
            DropIndex("dbo.Movimentacao", new[] { "VeiculoID" });
            DropIndex("dbo.Movimentacao", new[] { "EstabelecimentoID" });
            DropIndex("dbo.Veiculo", new[] { "ModeloID" });
            DropIndex("dbo.Modelo", new[] { "MarcaID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Movimentacao");
            DropTable("dbo.Veiculo");
            DropTable("dbo.Modelo");
            DropTable("dbo.Fabricante");
            DropTable("dbo.Estabelecimento");
        }
    }
}
