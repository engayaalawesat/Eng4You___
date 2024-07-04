namespace Eng4You.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamSecProgram : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NemSecPrograms", "ProgramID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NemSecPrograms", "ProgramID", c => c.Int(nullable: false));
        }
    }
}
