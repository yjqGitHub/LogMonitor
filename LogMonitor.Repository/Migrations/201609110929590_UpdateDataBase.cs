namespace LogMonitor.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_BrowseLogRecord", "IsLooked", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_LogRecord", "FIsNoticed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_LogRecord", "FIsNoticed");
            DropColumn("dbo.T_BrowseLogRecord", "IsLooked");
        }
    }
}
