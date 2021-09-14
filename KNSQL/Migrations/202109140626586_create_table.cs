namespace KNSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "School", c => c.String());
            AddColumn("dbo.People", "Subject", c => c.String());
            AddColumn("dbo.People", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Students", "StudentName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Address", c => c.String());
            AlterColumn("dbo.Students", "StudentName", c => c.String());
            DropColumn("dbo.People", "Discriminator");
            DropColumn("dbo.People", "Subject");
            DropColumn("dbo.People", "School");
        }
    }
}
