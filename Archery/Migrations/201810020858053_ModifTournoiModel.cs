namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifTournoiModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tournaments", "Location", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tournaments", "FeePerson", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tournaments", "FeePerson", c => c.Double(nullable: false));
            AlterColumn("dbo.Tournaments", "Location", c => c.String(nullable: false));
        }
    }
}
