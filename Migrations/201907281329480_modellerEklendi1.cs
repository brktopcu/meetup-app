namespace EtkinlikSitesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modellerEklendi1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EtkinlikTuru", "EtkinlikID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EtkinlikTuru", "EtkinlikID", c => c.Int(nullable: false));
        }
    }
}
