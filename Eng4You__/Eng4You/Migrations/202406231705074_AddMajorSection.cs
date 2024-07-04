namespace Eng4You.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMajorSection : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AddMajorSections", "FrontBookImageinEnglish");
            DropColumn("dbo.AddMajorSections", "RowVersionBookFrontinEnglish");
            DropColumn("dbo.AddMajorSections", "FrontBookImageinArabic");
            DropColumn("dbo.AddMajorSections", "RowVersionBookFrontinArabic");
            DropColumn("dbo.AddMajorSections", "FrontBookImageinTurkish");
            DropColumn("dbo.AddMajorSections", "RowVersionBookFrontinTurkish");
            DropColumn("dbo.AddMajorSections", "BackBookImage");
            DropColumn("dbo.AddMajorSections", "RowVersionBookBack");
            DropColumn("dbo.AddMajorSections", "UrlSeeBookinEnglish");
            DropColumn("dbo.AddMajorSections", "UrlSeeBookinArabic");
            DropColumn("dbo.AddMajorSections", "UrlSeeBookinTurkish");
            DropColumn("dbo.AddMajorSections", "BookDescriptioninEnglish");
            DropColumn("dbo.AddMajorSections", "BookDescriptioninArabic");
            DropColumn("dbo.AddMajorSections", "BookDescriptioninTurkish");
            DropColumn("dbo.AddMajorSections", "AoutherNameinEnglish");
            DropColumn("dbo.AddMajorSections", "AoutherNameinArabic");
            DropColumn("dbo.AddMajorSections", "AoutherNameinTurkish");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AddMajorSections", "AoutherNameinTurkish", c => c.String());
            AddColumn("dbo.AddMajorSections", "AoutherNameinArabic", c => c.String());
            AddColumn("dbo.AddMajorSections", "AoutherNameinEnglish", c => c.String());
            AddColumn("dbo.AddMajorSections", "BookDescriptioninTurkish", c => c.String());
            AddColumn("dbo.AddMajorSections", "BookDescriptioninArabic", c => c.String());
            AddColumn("dbo.AddMajorSections", "BookDescriptioninEnglish", c => c.String());
            AddColumn("dbo.AddMajorSections", "UrlSeeBookinTurkish", c => c.String());
            AddColumn("dbo.AddMajorSections", "UrlSeeBookinArabic", c => c.String());
            AddColumn("dbo.AddMajorSections", "UrlSeeBookinEnglish", c => c.String());
            AddColumn("dbo.AddMajorSections", "RowVersionBookBack", c => c.Binary());
            AddColumn("dbo.AddMajorSections", "BackBookImage", c => c.String());
            AddColumn("dbo.AddMajorSections", "RowVersionBookFrontinTurkish", c => c.Binary());
            AddColumn("dbo.AddMajorSections", "FrontBookImageinTurkish", c => c.String());
            AddColumn("dbo.AddMajorSections", "RowVersionBookFrontinArabic", c => c.Binary());
            AddColumn("dbo.AddMajorSections", "FrontBookImageinArabic", c => c.String());
            AddColumn("dbo.AddMajorSections", "RowVersionBookFrontinEnglish", c => c.Binary());
            AddColumn("dbo.AddMajorSections", "FrontBookImageinEnglish", c => c.String());
        }
    }
}
