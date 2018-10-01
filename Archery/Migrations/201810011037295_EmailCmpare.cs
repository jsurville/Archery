namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailCmpare : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Administrators", "Email", unique: true);
            CreateIndex("dbo.Archers", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Archers", new[] { "Email" });
            DropIndex("dbo.Administrators", new[] { "Email" });
        }
    }
}
