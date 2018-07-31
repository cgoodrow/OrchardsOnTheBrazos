namespace OrchardsOnTheBrazos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventName");
        }
    }
}
