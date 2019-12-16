namespace EtkinlikSitesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Etkinlik", "EtkinlikZamani", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Etkinlik", "EtkinlikZamani", c => c.String());
        }
    }
}
