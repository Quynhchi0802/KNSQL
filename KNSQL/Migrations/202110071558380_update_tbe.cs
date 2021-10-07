namespace KNSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbe : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.Accounts", "RoleID", c => c.String(maxLength: 10));
            AlterColumn("dbo.Roles", "RoleID", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Roles", "RoleName", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.Roles", "RoleID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.Roles", "RoleName", c => c.String());
            AlterColumn("dbo.Roles", "RoleID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Accounts", "RoleID", c => c.String());
            AddPrimaryKey("dbo.Roles", "RoleID");
        }
    }
}
