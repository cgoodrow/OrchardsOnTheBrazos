namespace OrchardsOnTheBrazos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrchardOnTheBrazos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Supports", "FileDetail_Id", "dbo.FileDetails");
            DropForeignKey("dbo.FileDetails", "Support_SupportId", "dbo.Supports");
            DropForeignKey("dbo.FileDetails", "Support_SupportId1", "dbo.Supports");
            DropIndex("dbo.FileDetails", new[] { "Support_SupportId" });
            DropIndex("dbo.FileDetails", new[] { "Support_SupportId1" });
            DropIndex("dbo.Supports", new[] { "FileDetail_Id" });
            DropTable("dbo.FileDetails");
            DropTable("dbo.Supports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Supports",
                c => new
                    {
                        SupportId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Summary = c.String(nullable: false, maxLength: 500),
                        FileDetail_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.SupportId);
            
            CreateTable(
                "dbo.FileDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        SupportId = c.Int(nullable: false),
                        Support_SupportId = c.Int(),
                        Support_SupportId1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Supports", "FileDetail_Id");
            CreateIndex("dbo.FileDetails", "Support_SupportId1");
            CreateIndex("dbo.FileDetails", "Support_SupportId");
            AddForeignKey("dbo.FileDetails", "Support_SupportId1", "dbo.Supports", "SupportId");
            AddForeignKey("dbo.FileDetails", "Support_SupportId", "dbo.Supports", "SupportId");
            AddForeignKey("dbo.Supports", "FileDetail_Id", "dbo.FileDetails", "Id");
        }
    }
}
