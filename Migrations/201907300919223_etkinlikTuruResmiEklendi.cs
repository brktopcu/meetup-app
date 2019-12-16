namespace EtkinlikSitesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class etkinlikTuruResmiEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EtkinlikTuru", "EtkinlikTuruResmi", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EtkinlikTuru", "EtkinlikTuruResmi");
        }
    }
}
