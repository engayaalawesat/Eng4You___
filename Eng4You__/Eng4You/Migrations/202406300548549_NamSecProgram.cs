namespace Eng4You.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamSecProgram : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NemSecPrograms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NamSecProgram = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NemSecPrograms");
        }
    }
}
