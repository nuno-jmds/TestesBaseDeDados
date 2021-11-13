namespace ExemploCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoCategoria : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Plataformas", name: "Nome", newName: "Name");
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConsoleGame",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        MidiaFisica = c.Boolean(nullable: false),
                        CaminhoFoto = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Games", "Position", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "Categoria_Id", c => c.Guid());
            CreateIndex("dbo.Games", "Categoria_Id");
            AddForeignKey("dbo.Games", "Categoria_Id", "dbo.Category", "Id");
            DropColumn("dbo.Games", "TipoJogo");
            DropColumn("dbo.Games", "Posicao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Posicao", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Games", "TipoJogo", c => c.String(maxLength: 50));
            DropForeignKey("dbo.ConsoleGame", "Id", "dbo.Games");
            DropForeignKey("dbo.Games", "Categoria_Id", "dbo.Category");
            DropIndex("dbo.ConsoleGame", new[] { "Id" });
            DropIndex("dbo.Games", new[] { "Categoria_Id" });
            DropColumn("dbo.Games", "Categoria_Id");
            DropColumn("dbo.Games", "Position");
            DropTable("dbo.ConsoleGame");
            DropTable("dbo.Category");
            RenameColumn(table: "dbo.Plataformas", name: "Name", newName: "Nome");
        }
    }
}
