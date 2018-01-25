namespace Fairy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "NumberAvailable", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "GenreId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropColumn("dbo.Books", "NumberAvailable");
            DropColumn("dbo.Books", "NumberInStock");
            DropColumn("dbo.Books", "ReleaseDate");
            DropColumn("dbo.Books", "DateAdded");
            DropColumn("dbo.Books", "GenreId");
        }
    }
}
