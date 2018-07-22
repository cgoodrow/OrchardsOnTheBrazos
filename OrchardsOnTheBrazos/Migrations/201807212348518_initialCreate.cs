namespace OrchardsOnTheBrazos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Supports", "Name", c => c.String());
            AlterColumn("dbo.Supports", "Summary", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Supports", "Summary", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Supports", "Name", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
