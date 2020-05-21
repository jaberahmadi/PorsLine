namespace Questionnaire.DataAccess.MSSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elmahinit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormSettings", "PeriodTime", c => c.Int(nullable: false));
            DropTable("dbo.Settings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeriodTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.FormSettings", "PeriodTime");
        }
    }
}
