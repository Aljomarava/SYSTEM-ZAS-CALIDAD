namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generarBD : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ubigeo", "PaisId", "dbo.Pais");
            DropIndex("dbo.Ubigeo", new[] { "PaisId" });
            DropColumn("dbo.Ubigeo", "PaisId");
            DropTable("dbo.Pais");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        PaisId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PaisId);
            
            AddColumn("dbo.Ubigeo", "PaisId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ubigeo", "PaisId");
            AddForeignKey("dbo.Ubigeo", "PaisId", "dbo.Pais", "PaisId");
        }
    }
}
