namespace Test_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Total = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.String(),
                        Unit_Price = c.String(),
                        BillId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.BillId, cascadeDelete: true)
                .Index(t => t.BillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "BillId", "dbo.Bills");
            DropIndex("dbo.Items", new[] { "BillId" });
            DropTable("dbo.Items");
            DropTable("dbo.Bills");
        }
    }
}
