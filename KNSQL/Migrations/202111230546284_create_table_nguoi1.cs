namespace KNSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_nguoi1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nguois",
                c => new
                    {
                        CCCD = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(),
                        DiaChi = c.String(),
                        CongTy = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CCCD);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nguois");
        }
    }
}
