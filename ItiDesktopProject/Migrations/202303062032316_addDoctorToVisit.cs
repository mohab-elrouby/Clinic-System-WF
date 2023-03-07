namespace ItiDesktopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoctorToVisit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visits", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Visits", "DoctorId");
            AddForeignKey("dbo.Visits", "DoctorId", "dbo.Doctors", "doctorID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Visits", new[] { "DoctorId" });
            DropColumn("dbo.Visits", "DoctorId");
        }
    }
}
