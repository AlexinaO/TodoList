namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutTache : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Taches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 30),
                        DateFin = c.DateTime(),
                        Statut = c.Boolean(nullable: false),
                        Priorite = c.Int(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: false)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taches", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Taches", new[] { "CategoryID" });
            DropTable("dbo.Taches");
        }
    }
}
