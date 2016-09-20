namespace LogMonitor.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataBase1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_BrowseLogRecord", "FAppDomain", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.T_BrowseLogRecord", "FUserAgent", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.T_LogRecord", "FAppDomain", c => c.String(maxLength: 300, unicode: false));
            AlterColumn("dbo.T_LogRecord", "FMessage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_LogRecord", "FMessage", c => c.String(maxLength: 800));
            AlterColumn("dbo.T_LogRecord", "FAppDomain", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.T_BrowseLogRecord", "FUserAgent", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.T_BrowseLogRecord", "FAppDomain", c => c.String(maxLength: 200, unicode: false));
        }
    }
}
