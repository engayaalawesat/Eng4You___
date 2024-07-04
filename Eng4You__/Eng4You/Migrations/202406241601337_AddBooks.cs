namespace Eng4You.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddBooks", "RowVersionFrontBookImageinEnglish", c => c.Binary());
            AddColumn("dbo.AddBooks", "RowVersionFrontBookImageinArabic", c => c.Binary());
            AddColumn("dbo.AddBooks", "RowVersionFrontBookImageinTurkish", c => c.Binary());
            AddColumn("dbo.AddBooks", "RowVersionBackBookImage", c => c.Binary());
            AddColumn("dbo.AddMajorSections", "FrontBookImageinEnglish", c => c.String());
            AddColumn("dbo.AddMajorSections", "FrontBookImageinArabic", c => c.String());
            AddColumn("dbo.AddMajorSections", "FrontBookImageinTurkish", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AddMajorSections", "FrontBookImageinTurkish");
            DropColumn("dbo.AddMajorSections", "FrontBookImageinArabic");
            DropColumn("dbo.AddMajorSections", "FrontBookImageinEnglish");
            DropColumn("dbo.AddBooks", "RowVersionBackBookImage");
            DropColumn("dbo.AddBooks", "RowVersionFrontBookImageinTurkish");
            DropColumn("dbo.AddBooks", "RowVersionFrontBookImageinArabic");
            DropColumn("dbo.AddBooks", "RowVersionFrontBookImageinEnglish");
        }
    }
}
