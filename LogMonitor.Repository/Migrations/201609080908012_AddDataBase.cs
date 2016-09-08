namespace LogMonitor.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_BrowseLogRecord",
                c => new
                    {
                        FId = c.Long(nullable: false, identity: true),
                        FAppDomain = c.String(maxLength: 200, unicode: false),
                        FProjectCode = c.String(maxLength: 50, unicode: false),
                        FRequestType = c.String(maxLength: 20, unicode: false),
                        FAbsoluteUrl = c.String(maxLength: 100, unicode: false),
                        FQueryUrl = c.String(maxLength: 400, unicode: false),
                        FRequestIp = c.String(maxLength: 15, unicode: false),
                        FIpAddress = c.String(maxLength: 50),
                        FUserAgent = c.String(maxLength: 200, unicode: false),
                        FRequestTime = c.DateTime(nullable: false),
                        FMessage = c.String(maxLength: 150, unicode: false),
                        FExecuteMillseconds = c.Double(nullable: false),
                        FAddTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.T_LogRecord",
                c => new
                    {
                        FId = c.Long(nullable: false, identity: true),
                        FLogType = c.Int(nullable: false),
                        FAppDomain = c.String(maxLength: 200, unicode: false),
                        FProjectId = c.Int(),
                        FProjectCode = c.String(maxLength: 50, unicode: false),
                        FModuleId = c.Int(),
                        FModuleCode = c.String(maxLength: 50, unicode: false),
                        FMessage = c.String(maxLength: 800),
                        FCreateTime = c.DateTime(nullable: false),
                        FAddTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.T_Module_Person",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FModuleId = c.Int(nullable: false),
                        FUserId = c.Int(nullable: false),
                        FIsManager = c.Boolean(nullable: false),
                        FIsDeleted = c.Boolean(nullable: false),
                        FAddTime = c.DateTime(nullable: false),
                        FModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.T_Project_Module",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FProjectId = c.Int(nullable: false),
                        FModuleName = c.String(maxLength: 50),
                        FModuleCode = c.String(maxLength: 50, unicode: false),
                        FDescription = c.String(maxLength: 80),
                        FIsDeleted = c.Boolean(nullable: false),
                        FCreater = c.Int(nullable: false),
                        FAddTime = c.DateTime(nullable: false),
                        FModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.T_Project_Person",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FProjectId = c.Int(nullable: false),
                        FUserId = c.Int(nullable: false),
                        FIsManager = c.Boolean(nullable: false),
                        FIsDeleted = c.Boolean(nullable: false),
                        FAddTime = c.DateTime(nullable: false),
                        FModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.T_Project",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FProjectName = c.String(maxLength: 50),
                        FProjectCode = c.String(maxLength: 50, unicode: false),
                        FDescription = c.String(maxLength: 80),
                        FIsDeleted = c.Boolean(nullable: false),
                        FCreater = c.Int(nullable: false),
                        FAddTime = c.DateTime(nullable: false),
                        FModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.T_User",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FUserName = c.String(maxLength: 50, unicode: false),
                        FPwd = c.String(maxLength: 32, unicode: false),
                        FSalt = c.String(maxLength: 8, unicode: false),
                        FName = c.String(nullable: false, maxLength: 50),
                        FEmail = c.String(maxLength: 50, unicode: false),
                        FMobile = c.String(maxLength: 11, unicode: false),
                        FIsAdmin = c.Boolean(nullable: false),
                        FIsDeleted = c.Boolean(nullable: false),
                        FAddTime = c.DateTime(nullable: false),
                        FModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.FId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_User");
            DropTable("dbo.T_Project");
            DropTable("dbo.T_Project_Person");
            DropTable("dbo.T_Project_Module");
            DropTable("dbo.T_Module_Person");
            DropTable("dbo.T_LogRecord");
            DropTable("dbo.T_BrowseLogRecord");
        }
    }
}
