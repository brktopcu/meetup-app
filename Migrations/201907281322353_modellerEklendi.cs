namespace EtkinlikSitesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modellerEklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etkinlik",
                c => new
                    {
                        EtkinlikID = c.Int(nullable: false, identity: true),
                        EtkinlikTuruID = c.Int(nullable: false),
                        EtkinlikAdi = c.String(),
                    })
                .PrimaryKey(t => t.EtkinlikID)
                .ForeignKey("dbo.EtkinlikTuru", t => t.EtkinlikTuruID, cascadeDelete: true)
                .Index(t => t.EtkinlikTuruID);
            
            CreateTable(
                "dbo.EtkinlikTuru",
                c => new
                    {
                        EtkinlikTuruID = c.Int(nullable: false, identity: true),
                        EtkinlikID = c.Int(nullable: false),
                        EtkinlikTuruAdi = c.String(),
                    })
                .PrimaryKey(t => t.EtkinlikTuruID);
            
            CreateTable(
                "dbo.Kayit",
                c => new
                    {
                        KayitID = c.Int(nullable: false, identity: true),
                        EtkinlikID = c.Int(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.KayitID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Etkinlik", t => t.EtkinlikID, cascadeDelete: true)
                .Index(t => t.EtkinlikID)
                .Index(t => t.ApplicationUserID);
            
            AddColumn("dbo.AspNetUsers", "AdiSoyadi", c => c.String());
            AddColumn("dbo.AspNetUsers", "Adres", c => c.String());
            AddColumn("dbo.AspNetUsers", "TelefonNo", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kayit", "EtkinlikID", "dbo.Etkinlik");
            DropForeignKey("dbo.Kayit", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Etkinlik", "EtkinlikTuruID", "dbo.EtkinlikTuru");
            DropIndex("dbo.Kayit", new[] { "ApplicationUserID" });
            DropIndex("dbo.Kayit", new[] { "EtkinlikID" });
            DropIndex("dbo.Etkinlik", new[] { "EtkinlikTuruID" });
            DropColumn("dbo.AspNetUsers", "TelefonNo");
            DropColumn("dbo.AspNetUsers", "Adres");
            DropColumn("dbo.AspNetUsers", "AdiSoyadi");
            DropTable("dbo.Kayit");
            DropTable("dbo.EtkinlikTuru");
            DropTable("dbo.Etkinlik");
        }
    }
}
