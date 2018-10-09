namespace OrchardsOnTheBrazos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001_intialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directories",
                c => new
                    {
                        DirectoryId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.DirectoryId);
            
            CreateTable(
                "dbo.DirectoryDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        DirectoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directories", t => t.DirectoryId, cascadeDelete: true)
                .Index(t => t.DirectoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DirectoryDetails", "DirectoryId", "dbo.Directories");
            DropIndex("dbo.DirectoryDetails", new[] { "DirectoryId" });
            DropTable("dbo.DirectoryDetails");
            DropTable("dbo.Directories");
        }
    }
}
