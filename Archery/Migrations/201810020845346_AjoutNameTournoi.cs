namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutNameTournoi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tournaments", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tournaments", "Name");
        }
    }
}
