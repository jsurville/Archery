namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DtaeObligatoireTournoi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tournaments", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tournaments", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tournaments", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Tournaments", "StartDate", c => c.DateTime());
        }
    }
}
