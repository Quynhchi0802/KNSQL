namespace KNSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_table_Rolee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "RoleID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "RoleID");
        }
    }
}
