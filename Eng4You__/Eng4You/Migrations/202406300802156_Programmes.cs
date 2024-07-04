namespace Eng4You.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Programmes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programmes", "NamSecProgramId", c => c.Int(nullable: false));
            AddColumn("dbo.Programmes", "NemSecProgram_Id", c => c.Int());
            CreateIndex("dbo.Programmes", "NemSecProgram_Id");
            AddForeignKey("dbo.Programmes", "NemSecProgram_Id", "dbo.NemSecPrograms", "Id");
            DropColumn("dbo.Programmes", "SectionName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programmes", "SectionName", c => c.String());
            DropForeignKey("dbo.Programmes", "NemSecProgram_Id", "dbo.NemSecPrograms");
            DropIndex("dbo.Programmes", new[] { "NemSecProgram_Id" });
            DropColumn("dbo.Programmes", "NemSecProgram_Id");
            DropColumn("dbo.Programmes", "NamSecProgramId");
        }
    }
}
