namespace ItiDesktopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWorkingHoursToDoctor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "WorkingHours", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "WorkingHours");
        }
    }
}
