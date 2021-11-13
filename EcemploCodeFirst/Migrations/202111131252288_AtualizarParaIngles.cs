namespace ExemploCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizarParaIngles : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Jogos", newName: "Games");
            RenameColumn(table: "dbo.Games", name: "Nome", newName: "Name");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Games", name: "Name", newName: "Nome");
            RenameTable(name: "dbo.Games", newName: "Jogos");
        }
    }
}
