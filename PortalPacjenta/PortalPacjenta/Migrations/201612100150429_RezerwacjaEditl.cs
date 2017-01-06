namespace PortalPacjenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RezerwacjaEditl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rezerwacje", "godzOd", c => c.String());
            DropColumn("dbo.Rezerwacje", "Stat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rezerwacje", "Stat", c => c.String(maxLength: 1));
            AlterColumn("dbo.Rezerwacje", "godzOd", c => c.String(nullable: false));
        }
    }
}
