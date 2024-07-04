namespace Eng4You.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    
    public partial class NamSecProgram : DbMigration
    {
        internal readonly ICollection<Models.Programmes> Programmes;

        public override void Up()
        {
            AddColumn("dbo.NemSecPrograms", "ProgramID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NemSecPrograms", "ProgramID");
        }
    }
}
