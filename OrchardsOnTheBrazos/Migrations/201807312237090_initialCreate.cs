namespace OrchardsOnTheBrazos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Supports", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Supports", "Summary", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Supports", "Summary", c => c.String());
            AlterColumn("dbo.Supports", "Name", c => c.String());
            DropColumn("dbo.Events", "EventDate");
        }
    }
}
