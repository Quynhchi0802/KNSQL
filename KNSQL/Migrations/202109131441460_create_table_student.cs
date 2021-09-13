namespace KNSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_student : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Uesname = c.String(nullable: false, maxLength: 50, unicode: false),
                        password = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Uesname);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        StudentName = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
            DropTable("dbo.Account");
        }
    }
}
