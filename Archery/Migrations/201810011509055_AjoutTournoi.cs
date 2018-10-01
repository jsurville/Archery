namespace Archery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutTournoi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BowTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        FeePerson = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Shooters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TournamentID = c.Int(nullable: false),
                        BowTypeID = c.Int(nullable: false),
                        ArcherID = c.Int(nullable: false),
                        StatTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Archers", t => t.ArcherID, cascadeDelete: true)
                .ForeignKey("dbo.BowTypes", t => t.BowTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Tournaments", t => t.TournamentID, cascadeDelete: false)
                .Index(t => t.TournamentID)
                .Index(t => t.BowTypeID)
                .Index(t => t.ArcherID);
            
            CreateTable(
                "dbo.TournamentBowTypes",
                c => new
                    {
                        Tournament_ID = c.Int(nullable: false),
                        BowType_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tournament_ID, t.BowType_ID })
                .ForeignKey("dbo.Tournaments", t => t.Tournament_ID, cascadeDelete: true)
                .ForeignKey("dbo.BowTypes", t => t.BowType_ID, cascadeDelete: false)
                .Index(t => t.Tournament_ID)
                .Index(t => t.BowType_ID);
            
            AddColumn("dbo.Archers", "Tournament_ID", c => c.Int());
            CreateIndex("dbo.Archers", "Tournament_ID");
            AddForeignKey("dbo.Archers", "Tournament_ID", "dbo.Tournaments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shooters", "TournamentID", "dbo.Tournaments");
            DropForeignKey("dbo.Shooters", "BowTypeID", "dbo.BowTypes");
            DropForeignKey("dbo.Shooters", "ArcherID", "dbo.Archers");
            DropForeignKey("dbo.TournamentBowTypes", "BowType_ID", "dbo.BowTypes");
            DropForeignKey("dbo.TournamentBowTypes", "Tournament_ID", "dbo.Tournaments");
            DropForeignKey("dbo.Archers", "Tournament_ID", "dbo.Tournaments");
            DropIndex("dbo.TournamentBowTypes", new[] { "BowType_ID" });
            DropIndex("dbo.TournamentBowTypes", new[] { "Tournament_ID" });
            DropIndex("dbo.Shooters", new[] { "ArcherID" });
            DropIndex("dbo.Shooters", new[] { "BowTypeID" });
            DropIndex("dbo.Shooters", new[] { "TournamentID" });
            DropIndex("dbo.Archers", new[] { "Tournament_ID" });
            DropColumn("dbo.Archers", "Tournament_ID");
            DropTable("dbo.TournamentBowTypes");
            DropTable("dbo.Shooters");
            DropTable("dbo.Tournaments");
            DropTable("dbo.BowTypes");
        }
    }
}
