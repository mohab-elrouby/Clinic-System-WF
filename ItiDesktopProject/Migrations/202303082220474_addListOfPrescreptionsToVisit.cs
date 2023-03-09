namespace ItiDesktopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addListOfPrescreptionsToVisit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "Visit_VisitID", c => c.Int());
            CreateIndex("dbo.Prescriptions", "Visit_VisitID");
            AddForeignKey("dbo.Prescriptions", "Visit_VisitID", "dbo.Visits", "VisitID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "Visit_VisitID", "dbo.Visits");
            DropIndex("dbo.Prescriptions", new[] { "Visit_VisitID" });
            DropColumn("dbo.Prescriptions", "Visit_VisitID");
        }
    }
}
