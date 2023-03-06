namespace ItiDesktopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVisitTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visits", "visit_time", c => c.String());
            AlterColumn("dbo.Doctors", "phonNumber", c => c.String());
            AlterColumn("dbo.Patients", "phonnumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "phonnumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Doctors", "phonNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Visits", "visit_time");
        }
    }
}
