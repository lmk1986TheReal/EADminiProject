namespace EADMiniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Band",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BandName = c.String(nullable: false),
                        NumberofBandMembers = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        YearsActive = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Musician",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MusicianFirstName = c.String(nullable: false),
                        MusicianLastName = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        YearsActive = c.String(nullable: false),
                        PrimaryInstrument = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Musician");
            DropTable("dbo.Band");
        }
    }
}
