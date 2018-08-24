namespace OrchardsOnTheBrazos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01_initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Site = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Infoes");
        }
    }
}
