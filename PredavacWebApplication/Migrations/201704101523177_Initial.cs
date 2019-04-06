namespace PredavacWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kolegijs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Nositelj = c.String(),
                        StudijskaGod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Predavacs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Tema = c.String(),
                        Datum = c.DateTime(nullable: false),
                        BrStudent = c.Int(nullable: false),
                        KolegijId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kolegijs", t => t.KolegijId, cascadeDelete: true)
                .Index(t => t.KolegijId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Predavacs", "KolegijId", "dbo.Kolegijs");
            DropIndex("dbo.Predavacs", new[] { "KolegijId" });
            DropTable("dbo.Predavacs");
            DropTable("dbo.Kolegijs");
        }
    }
}
