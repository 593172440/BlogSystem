namespace BlogSystem.models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        GoodCount = c.Int(nullable: false),
                        BadCount = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        ImagePath = c.String(),
                        FansCount = c.Int(nullable: false),
                        FocusCount = c.Int(nullable: false),
                        SiteName = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleToCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogCategory_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategory_Id)
                .Index(t => t.BlogCategory_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        UserId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Content = c.String(),
                        Article_Id = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.Fans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        FocusUser_Id = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsRemove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FocusUser_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id)
                .Index(t => t.FocusUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fans", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Fans", "FocusUser_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.ArticleToCategories", "BlogCategory_Id", "dbo.BlogCategories");
            DropForeignKey("dbo.BlogCategories", "UserId", "dbo.Users");
            DropForeignKey("dbo.ArticleToCategories", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Articles", "User_Id", "dbo.Users");
            DropIndex("dbo.Fans", new[] { "FocusUser_Id" });
            DropIndex("dbo.Fans", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Article_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.BlogCategories", new[] { "UserId" });
            DropIndex("dbo.ArticleToCategories", new[] { "Article_Id" });
            DropIndex("dbo.ArticleToCategories", new[] { "BlogCategory_Id" });
            DropIndex("dbo.Articles", new[] { "User_Id" });
            DropTable("dbo.Fans");
            DropTable("dbo.Comments");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.ArticleToCategories");
            DropTable("dbo.Users");
            DropTable("dbo.Articles");
        }
    }
}
