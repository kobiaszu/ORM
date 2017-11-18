namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestDBModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prop = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestDBModels");
        }
    }
}
