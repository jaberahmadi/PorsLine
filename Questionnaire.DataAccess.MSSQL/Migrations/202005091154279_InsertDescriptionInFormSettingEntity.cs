namespace Questionnaire.DataAccess.MSSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDescriptionInFormSettingEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormSettings", "Descriptions", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FormSettings", "Descriptions");
        }
    }
}
