namespace ItiDesktopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRelationBetweenPrescriptionAndVisit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prescriptions", "ID", "dbo.Visits");
            DropIndex("dbo.Prescriptions", new[] { "ID" });
            DropPrimaryKey("dbo.Prescriptions");
            AlterColumn("dbo.Prescriptions", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Prescriptions", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Prescriptions");
            AlterColumn("dbo.Prescriptions", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Prescriptions", "ID");
            CreateIndex("dbo.Prescriptions", "ID");
            AddForeignKey("dbo.Prescriptions", "ID", "dbo.Visits", "VisitID");
        }
    }
}
