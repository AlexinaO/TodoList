namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChgtTache : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Taches", "Description", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Taches", "Description", c => c.String(maxLength: 30));
        }
    }
}
