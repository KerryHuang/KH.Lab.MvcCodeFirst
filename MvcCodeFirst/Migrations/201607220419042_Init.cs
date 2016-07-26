namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemRoles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sort = c.Int(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        CreateBy = c.Guid(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        UpdateOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemUsers",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Account = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 200),
                        IsEnable = c.Boolean(nullable: false),
                        CreateBy = c.Guid(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        UpdateOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemUserSystemRoles",
                c => new
                    {
                        SystemUser_ID = c.Guid(nullable: false),
                        SystemRole_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SystemUser_ID, t.SystemRole_ID })
                .ForeignKey("dbo.SystemUsers", t => t.SystemUser_ID, cascadeDelete: true)
                .ForeignKey("dbo.SystemRoles", t => t.SystemRole_ID, cascadeDelete: true)
                .Index(t => t.SystemUser_ID)
                .Index(t => t.SystemRole_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemUserSystemRoles", "SystemRole_ID", "dbo.SystemRoles");
            DropForeignKey("dbo.SystemUserSystemRoles", "SystemUser_ID", "dbo.SystemUsers");
            DropIndex("dbo.SystemUserSystemRoles", new[] { "SystemRole_ID" });
            DropIndex("dbo.SystemUserSystemRoles", new[] { "SystemUser_ID" });
            DropTable("dbo.SystemUserSystemRoles");
            DropTable("dbo.SystemUsers");
            DropTable("dbo.SystemRoles");
        }
    }
}
