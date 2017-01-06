namespace PortalPacjenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KodPocztowy = c.String(),
                        Miasto = c.String(maxLength: 60),
                        Ulica = c.String(maxLength: 60),
                        NrDomu = c.String(maxLength: 10),
                        NrLokalu = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Opcje",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Typ = c.Int(nullable: false),
                        Wartosc = c.String(),
                        Ostatnia_modyfikacja = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pacjenci",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataUrodzenia = c.DateTime(),
                        Plec = c.String(),
                        DokumentTozsamosci = c.String(),
                        Imie = c.String(nullable: false, maxLength: 50),
                        Nazwisko = c.String(nullable: false, maxLength: 60),
                        Pesel = c.String(),
                        Telefon = c.String(maxLength: 9),
                        Email = c.String(maxLength: 100),
                        Aktw = c.String(maxLength: 1),
                        Adres_Id = c.Int(),
                        AdresTymczasowy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Adresy", t => t.Adres_Id)
                .ForeignKey("dbo.Adresy", t => t.AdresTymczasowy_Id)
                .Index(t => t.Adres_Id)
                .Index(t => t.AdresTymczasowy_Id);
            
            CreateTable(
                "dbo.Pracownicy",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Specjalizacja = c.String(maxLength: 100),
                        PWZ = c.String(maxLength: 8),
                        TytulNaukowy = c.String(maxLength: 15),
                        Imie = c.String(nullable: false, maxLength: 50),
                        Nazwisko = c.String(nullable: false, maxLength: 60),
                        Pesel = c.String(),
                        Telefon = c.String(maxLength: 9),
                        Email = c.String(maxLength: 100),
                        Aktw = c.String(maxLength: 1),
                        Adres_Id = c.Int(),
                        AdresTymczasowy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Adresy", t => t.Adres_Id)
                .ForeignKey("dbo.Adresy", t => t.AdresTymczasowy_Id)
                .Index(t => t.Adres_Id)
                .Index(t => t.AdresTymczasowy_Id);
            
            CreateTable(
                "dbo.Rezerwacje",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataRezerwacji = c.DateTime(nullable: false),
                        godzOd = c.String(),
                        godzDo = c.String(),
                        DataModyfikacji = c.DateTime(nullable: false),
                        PracownikID = c.Int(nullable: false),
                        PacjentID = c.Int(nullable: false),
                        Stat = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pacjenci", t => t.PacjentID, cascadeDelete: true)
                .ForeignKey("dbo.Pracownicy", t => t.PracownikID, cascadeDelete: true)
                .Index(t => t.PracownikID)
                .Index(t => t.PacjentID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Uzytkowicy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50),
                        Haslo = c.String(nullable: false, maxLength: 100),
                        DataUtworzenia = c.DateTime(),
                        PracownikID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pracownicy", t => t.PracownikID)
                .Index(t => t.PracownikID);
            
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
            DropForeignKey("dbo.Uzytkowicy", "PracownikID", "dbo.Pracownicy");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Rezerwacje", "PracownikID", "dbo.Pracownicy");
            DropForeignKey("dbo.Rezerwacje", "PacjentID", "dbo.Pacjenci");
            DropForeignKey("dbo.Pracownicy", "AdresTymczasowy_Id", "dbo.Adresy");
            DropForeignKey("dbo.Pracownicy", "Adres_Id", "dbo.Adresy");
            DropForeignKey("dbo.Pacjenci", "AdresTymczasowy_Id", "dbo.Adresy");
            DropForeignKey("dbo.Pacjenci", "Adres_Id", "dbo.Adresy");
            DropIndex("dbo.Wizyty", new[] { "RezerwacjaId" });
            DropIndex("dbo.Wizyty", new[] { "PacjentID" });
            DropIndex("dbo.Wizyty", new[] { "PracownikID" });
            DropIndex("dbo.Uzytkowicy", new[] { "PracownikID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Rezerwacje", new[] { "PacjentID" });
            DropIndex("dbo.Rezerwacje", new[] { "PracownikID" });
            DropIndex("dbo.Pracownicy", new[] { "AdresTymczasowy_Id" });
            DropIndex("dbo.Pracownicy", new[] { "Adres_Id" });
            DropIndex("dbo.Pacjenci", new[] { "AdresTymczasowy_Id" });
            DropIndex("dbo.Pacjenci", new[] { "Adres_Id" });
            DropTable("dbo.Wizyty");
            DropTable("dbo.Uzytkowicy");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rezerwacje");
            DropTable("dbo.Pracownicy");
            DropTable("dbo.Pacjenci");
            DropTable("dbo.Opcje");
            DropTable("dbo.Adresy");
        }
    }
}
