namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg55 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kariyars",
                c => new
                    {
                        KisiID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        SurName = c.String(),
                        Meslek = c.String(),
                        Okul = c.String(),
                        NotOrtalaması = c.String(),
                        DogumTarihi = c.DateTime(nullable: false),
                        DogumYeri = c.String(),
                        Cinsiyet = c.String(),
                        Email = c.String(),
                        Telefon = c.String(),
                        Maas = c.String(),
                        Calısmakİstediginiz = c.String(),
                        AskerlikDurum = c.String(),
                        MedeniDurumu = c.String(),
                    })
                .PrimaryKey(t => t.KisiID);
            
            CreateTable(
                "dbo.Siparis",
                c => new
                    {
                        SiparisID = c.Int(nullable: false, identity: true),
                        KovanTipi = c.String(),
                        PabucTipi = c.String(),
                        AraBoru = c.String(),
                        ÇevirmeBoru = c.String(),
                        adet = c.Int(nullable: false),
                        AdSoyad = c.String(),
                        Firmaİsmi = c.String(),
                        Telefon = c.String(),
                        VergiDairesi = c.String(),
                        VergiNo = c.String(),
                        Mail = c.String(),
                        Notlar = c.String(),
                        Fiyat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SiparisID);
            
            CreateTable(
                "dbo.Siparis1",
                c => new
                    {
                        Siparis1ID = c.Int(nullable: false, identity: true),
                        UrunKodu = c.String(),
                        adet = c.Int(nullable: false),
                        AdSoyad = c.String(),
                        Firmaİsmi = c.String(),
                        Telefon = c.String(),
                        VergiDairesi = c.String(),
                        VergiNo = c.String(),
                        Mail = c.String(),
                        Notlar = c.String(),
                        Fiyat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Siparis1ID);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialID = c.Int(nullable: false, identity: true),
                        TestimonialName = c.String(),
                        TestimonialTitle = c.String(),
                        TestimonialAcıklama = c.String(),
                    })
                .PrimaryKey(t => t.TestimonialID);
            
            AddColumn("dbo.Admins", "AdminRole", c => c.Int(nullable: false));
            AddColumn("dbo.Authors", "AuthorTitle", c => c.String());
            AddColumn("dbo.Authors", "AuthorSort", c => c.String());
            AddColumn("dbo.Authors", "Mail", c => c.String());
            AddColumn("dbo.Authors", "Instagram", c => c.String());
            AddColumn("dbo.Authors", "Facebook", c => c.String());
            AddColumn("dbo.Authors", "Twitter", c => c.String());
            AddColumn("dbo.Authors", "Password", c => c.String());
            AddColumn("dbo.Authors", "Telefon", c => c.String());
            AddColumn("dbo.Authors", "Category_CategoryID", c => c.Int());
            AddColumn("dbo.Blogs", "BlogTitleEng", c => c.String());
            AddColumn("dbo.Blogs", "BlogImage1", c => c.String());
            AddColumn("dbo.Blogs", "BlogImage2", c => c.String());
            AddColumn("dbo.Blogs", "BlogAcıklama", c => c.String());
            AddColumn("dbo.Blogs", "BlogAcıklama1", c => c.String());
            AddColumn("dbo.Blogs", "BlogAcıklama2", c => c.String());
            AddColumn("dbo.Blogs", "BlogAcıklama3", c => c.String());
            AddColumn("dbo.Blogs", "BlogAcıklama4", c => c.String());
            AddColumn("dbo.Blogs", "BlogAcıklama5", c => c.String());
            AddColumn("dbo.Blogs", "BlogAcıklama6", c => c.String());
            AddColumn("dbo.Blogs", "BlogAcıklama7", c => c.String());
            AddColumn("dbo.Blogs", "BlogAcıklama8", c => c.String());
            AddColumn("dbo.Blogs", "BlogAcıklama9", c => c.String());
            AddColumn("dbo.Blogs", "BlogAcıklama10", c => c.String());
            AddColumn("dbo.Blogs", "KaldırmaKapasite", c => c.Int(nullable: false));
            AddColumn("dbo.Blogs", "Fabrika", c => c.String());
            AddColumn("dbo.Blogs", "TraktörMarka", c => c.String());
            AddColumn("dbo.Blogs", "tablo1Baslık1", c => c.String());
            AddColumn("dbo.Blogs", "tabloBaslık2", c => c.String());
            AddColumn("dbo.Blogs", "tabloBaslık3", c => c.String());
            AddColumn("dbo.Blogs", "tabloBaslık4", c => c.String());
            AddColumn("dbo.Blogs", "tabloBaslık5", c => c.String());
            AddColumn("dbo.Blogs", "Tabloİcerik1", c => c.String());
            AddColumn("dbo.Blogs", "Tabloİçerik2", c => c.String());
            AddColumn("dbo.Blogs", "Tabloİcerik3", c => c.String());
            AddColumn("dbo.Blogs", "Tabloİcerik4", c => c.String());
            AddColumn("dbo.Blogs", "Tabloİcerik5", c => c.String());
            AddColumn("dbo.Blogs", "SiparisKod", c => c.String());
            AddColumn("dbo.Blogs", "BlogRating", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "CategoryAcıklama", c => c.String());
            AddColumn("dbo.Comments", "CommentStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "BlogRating", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "Message", c => c.String());
            CreateIndex("dbo.Authors", "Category_CategoryID");
            AddForeignKey("dbo.Authors", "Category_CategoryID", "dbo.Categories", "CategoryID");
            DropColumn("dbo.Blogs", "BlogContent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "BlogContent", c => c.String());
            DropForeignKey("dbo.Authors", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.Authors", new[] { "Category_CategoryID" });
            DropColumn("dbo.Contacts", "Message");
            DropColumn("dbo.Comments", "BlogRating");
            DropColumn("dbo.Comments", "CommentStatus");
            DropColumn("dbo.Categories", "CategoryAcıklama");
            DropColumn("dbo.Blogs", "BlogRating");
            DropColumn("dbo.Blogs", "SiparisKod");
            DropColumn("dbo.Blogs", "Tabloİcerik5");
            DropColumn("dbo.Blogs", "Tabloİcerik4");
            DropColumn("dbo.Blogs", "Tabloİcerik3");
            DropColumn("dbo.Blogs", "Tabloİçerik2");
            DropColumn("dbo.Blogs", "Tabloİcerik1");
            DropColumn("dbo.Blogs", "tabloBaslık5");
            DropColumn("dbo.Blogs", "tabloBaslık4");
            DropColumn("dbo.Blogs", "tabloBaslık3");
            DropColumn("dbo.Blogs", "tabloBaslık2");
            DropColumn("dbo.Blogs", "tablo1Baslık1");
            DropColumn("dbo.Blogs", "TraktörMarka");
            DropColumn("dbo.Blogs", "Fabrika");
            DropColumn("dbo.Blogs", "KaldırmaKapasite");
            DropColumn("dbo.Blogs", "BlogAcıklama10");
            DropColumn("dbo.Blogs", "BlogAcıklama9");
            DropColumn("dbo.Blogs", "BlogAcıklama8");
            DropColumn("dbo.Blogs", "BlogAcıklama7");
            DropColumn("dbo.Blogs", "BlogAcıklama6");
            DropColumn("dbo.Blogs", "BlogAcıklama5");
            DropColumn("dbo.Blogs", "BlogAcıklama4");
            DropColumn("dbo.Blogs", "BlogAcıklama3");
            DropColumn("dbo.Blogs", "BlogAcıklama2");
            DropColumn("dbo.Blogs", "BlogAcıklama1");
            DropColumn("dbo.Blogs", "BlogAcıklama");
            DropColumn("dbo.Blogs", "BlogImage2");
            DropColumn("dbo.Blogs", "BlogImage1");
            DropColumn("dbo.Blogs", "BlogTitleEng");
            DropColumn("dbo.Authors", "Category_CategoryID");
            DropColumn("dbo.Authors", "Telefon");
            DropColumn("dbo.Authors", "Password");
            DropColumn("dbo.Authors", "Twitter");
            DropColumn("dbo.Authors", "Facebook");
            DropColumn("dbo.Authors", "Instagram");
            DropColumn("dbo.Authors", "Mail");
            DropColumn("dbo.Authors", "AuthorSort");
            DropColumn("dbo.Authors", "AuthorTitle");
            DropColumn("dbo.Admins", "AdminRole");
            DropTable("dbo.Testimonials");
            DropTable("dbo.Siparis1");
            DropTable("dbo.Siparis");
            DropTable("dbo.Kariyars");
        }
    }
}
