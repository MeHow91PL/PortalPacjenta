namespace PortalPacjenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedWitzyta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wizyty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataWizyty = c.DateTime(nullable: false),
                        godzOd = c.String(),
                        godzDo = c.String(),
                        DataModyfikacji = c.DateTime(nullable: false),
                        PracownikID = c.Int(nullable: false),
                        PacjentID = c.Int(nullable: false),
                        RezerwacjaId = c.Int(),
                        Rozpoznanie = c.String(),
                        Badanie = c.String(),
                        Wywiad = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pacjenci", t => t.PacjentID, cascadeDelete: true)
                .ForeignKey("dbo.Pracownicy", t => t.PracownikID, cascadeDelete: true)
                .ForeignKey("dbo.Rezerwacje", t => t.RezerwacjaId)
                .Index(t => t.PracownikID)
                .Index(t => t.PacjentID)
                .Index(t => t.RezerwacjaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wizyty", "RezerwacjaId", "dbo.Rezerwacje");
            DropForeignKey("dbo.Wizyty", "PracownikID", "dbo.Pracownicy");
            DropForeignKey("dbo.Wizyty", "PacjentID", "dbo.Pacjenci");
            DropIndex("dbo.Wizyty", new[] { "RezerwacjaId" });
            DropIndex("dbo.Wizyty", new[] { "PacjentID" });
            DropIndex("dbo.Wizyty", new[] { "PracownikID" });
            DropTable("dbo.Wizyty");
        }
    }
}
