namespace EtkinlikSitesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class etkinlikAciklamaEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EtkinlikTuru", "EtkinlikTuruAciklama", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EtkinlikTuru", "EtkinlikTuruAciklama");
        }
    }
}
