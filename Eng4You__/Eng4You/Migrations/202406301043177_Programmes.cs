namespace Eng4You.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Programmes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NemSecPrograms", "ProgramId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NemSecPrograms", "ProgramId");
        }
    }
}
