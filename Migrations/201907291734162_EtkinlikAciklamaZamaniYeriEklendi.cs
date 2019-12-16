namespace EtkinlikSitesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EtkinlikAciklamaZamaniYeriEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Etkinlik", "EtkinlikAciklama", c => c.String());
            AddColumn("dbo.Etkinlik", "EtkinlikZamani", c => c.String());
            AddColumn("dbo.Etkinlik", "EtkinlikYeri", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Etkinlik", "EtkinlikYeri");
            DropColumn("dbo.Etkinlik", "EtkinlikZamani");
            DropColumn("dbo.Etkinlik", "EtkinlikAciklama");
        }
    }
}
