namespace KNSQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_nguoi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Article", "ArticleName", c => c.String());
            AddColumn("dbo.Article", "ArticleAdress", c => c.String());
            DropColumn("dbo.Article", "Author");
            DropColumn("dbo.Article", "ArticleContent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Article", "ArticleContent", c => c.String());
            AddColumn("dbo.Article", "Author", c => c.String());
            DropColumn("dbo.Article", "ArticleAdress");
            DropColumn("dbo.Article", "ArticleName");
        }
    }
}
