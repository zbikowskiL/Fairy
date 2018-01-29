namespace Fairy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDENTITY_INSERT_OFF : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Books OFF");
            Sql("SET IDENTITY_INSERT Genres OFF");
        }
        
        public override void Down()
        {
        }
    }
}
