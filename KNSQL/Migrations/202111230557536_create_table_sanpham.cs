namespace KNSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_sanpham : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoaiSanPhams",
                c => new
                    {
                        LoaiSanPhamID = c.String(nullable: false, maxLength: 128),
                        TenLoaiSanPham = c.String(),
                    })
                .PrimaryKey(t => t.LoaiSanPhamID);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        SanPhamID = c.String(nullable: false, maxLength: 128),
                        TenSanPham = c.String(),
                        LoaiSanPhamID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SanPhamID)
                .ForeignKey("dbo.LoaiSanPhams", t => t.LoaiSanPhamID)
                .Index(t => t.LoaiSanPhamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "LoaiSanPhamID", "dbo.LoaiSanPhams");
            DropIndex("dbo.SanPhams", new[] { "LoaiSanPhamID" });
            DropTable("dbo.SanPhams");
            DropTable("dbo.LoaiSanPhams");
        }
    }
}
