namespace ItiDesktopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPatientIdToVisit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Visits", "Patient_ID", "dbo.Patients");
            DropIndex("dbo.Visits", new[] { "Patient_ID" });
            RenameColumn(table: "dbo.Visits", name: "Patient_ID", newName: "PatientID");
            AlterColumn("dbo.Visits", "PatientID", c => c.Int(nullable: false));
            CreateIndex("dbo.Visits", "PatientID");
            AddForeignKey("dbo.Visits", "PatientID", "dbo.Patients", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "PatientID", "dbo.Patients");
            DropIndex("dbo.Visits", new[] { "PatientID" });
            AlterColumn("dbo.Visits", "PatientID", c => c.Int());
            RenameColumn(table: "dbo.Visits", name: "PatientID", newName: "Patient_ID");
            CreateIndex("dbo.Visits", "Patient_ID");
            AddForeignKey("dbo.Visits", "Patient_ID", "dbo.Patients", "ID");
        }
    }
}
