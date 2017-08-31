namespace BookStoreManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.S4452232",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Index = c.Int(nullable: false),
                        Name = c.String(),
                        Author = c.String(),
                        Year = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.S4452232");
        }
    }
}
