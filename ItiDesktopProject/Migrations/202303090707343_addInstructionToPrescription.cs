namespace ItiDesktopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInstructionToPrescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "Instruction", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prescriptions", "Instruction");
        }
    }
}
