namespace ItiDesktopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteBillFromService : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "Bills_billsID", "dbo.Bills");
            DropIndex("dbo.Services", new[] { "Bills_billsID" });
            DropColumn("dbo.Services", "Bills_billsID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Bills_billsID", c => c.Int());
            CreateIndex("dbo.Services", "Bills_billsID");
            AddForeignKey("dbo.Services", "Bills_billsID", "dbo.Bills", "billsID");
        }
    }
}
