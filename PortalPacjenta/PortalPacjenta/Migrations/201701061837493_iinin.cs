namespace PortalPacjenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iinin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wizyty", "PacjentID", "dbo.Pacjenci");
            DropForeignKey("dbo.Wizyty", "PracownikID", "dbo.Pracownicy");
            DropForeignKey("dbo.Wizyty", "RezerwacjaId", "dbo.Rezerwacje");
            DropIndex("dbo.Wizyty", new[] { "PracownikID" });
            DropIndex("dbo.Wizyty", new[] { "PacjentID" });
            DropIndex("dbo.Wizyty", new[] { "RezerwacjaId" });
            DropColumn("dbo.Rezerwacje", "Stat");
            DropTable("dbo.Wizyty");
        }
        
        public override void Down()
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
                        Zalecenia = c.String(),
                        Leki = c.String(),
                        Skierowanie = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rezerwacje", "Stat", c => c.String(maxLength: 1));
            CreateIndex("dbo.Wizyty", "RezerwacjaId");
            CreateIndex("dbo.Wizyty", "PacjentID");
            CreateIndex("dbo.Wizyty", "PracownikID");
            AddForeignKey("dbo.Wizyty", "RezerwacjaId", "dbo.Rezerwacje", "Id");
            AddForeignKey("dbo.Wizyty", "PracownikID", "dbo.Pracownicy", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Wizyty", "PacjentID", "dbo.Pacjenci", "ID", cascadeDelete: true);
        }
    }
}
