namespace ItiDesktopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        billsID = c.Int(nullable: false),
                        totalCost = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.billsID)
                .ForeignKey("dbo.Visits", t => t.billsID)
                .Index(t => t.billsID);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitID = c.Int(nullable: false, identity: true),
                        Visit_Status = c.Byte(nullable: false),
                        visit_date = c.String(),
                        Clinc_clinicID = c.Int(),
                        Patient_ID = c.Int(),
                    })
                .PrimaryKey(t => t.VisitID)
                .ForeignKey("dbo.Clinics", t => t.Clinc_clinicID)
                .ForeignKey("dbo.Patients", t => t.Patient_ID)
                .Index(t => t.Clinc_clinicID)
                .Index(t => t.Patient_ID);
            
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        clinicID = c.Int(nullable: false, identity: true),
                        clinic_name = c.String(),
                        start_time = c.String(),
                        end_time = c.String(),
                    })
                .PrimaryKey(t => t.clinicID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        doctorID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        age = c.Int(nullable: false),
                        percentage = c.Single(nullable: false),
                        phonNumber = c.Int(nullable: false),
                        Gender = c.String(),
                        Mirtal_Status = c.String(),
                        Email = c.String(),
                        AccountantEmail = c.String(),
                        Contract = c.String(),
                        ClinicId = c.Int(nullable: false),
                        UserTypes_ID = c.Int(),
                    })
                .PrimaryKey(t => t.doctorID)
                .ForeignKey("dbo.Clinics", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserTypes_ID)
                .Index(t => t.ClinicId)
                .Index(t => t.UserTypes_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.Int(nullable: false),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reseptionests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        adress = c.String(),
                        age = c.Int(nullable: false),
                        phonnumber = c.Int(nullable: false),
                        gender = c.String(),
                        mirtal_status = c.String(),
                        Email = c.String(),
                        hiringdate = c.String(),
                        Usertypes_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Usertypes_ID)
                .Index(t => t.Usertypes_ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        servcsesname = c.String(),
                        cost = c.Single(nullable: false),
                        Bills_billsID = c.Int(),
                        Clinic_clinicID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bills", t => t.Bills_billsID)
                .ForeignKey("dbo.Clinics", t => t.Clinic_clinicID)
                .Index(t => t.Bills_billsID)
                .Index(t => t.Clinic_clinicID);
            
            CreateTable(
                "dbo.Diagnoses",
                c => new
                    {
                        DiagnosesID = c.Int(nullable: false),
                        DiagnosesTxt = c.String(),
                    })
                .PrimaryKey(t => t.DiagnosesID)
                .ForeignKey("dbo.Visits", t => t.DiagnosesID)
                .Index(t => t.DiagnosesID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        age = c.Int(),
                        phonnumber = c.Int(nullable: false),
                        gender = c.String(),
                        mirtal_status = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        medicen_name = c.String(),
                        Dose = c.Int(),
                        Duration = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Visits", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.BillServices",
                c => new
                    {
                        BillID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        Bill_billsID = c.Int(),
                    })
                .PrimaryKey(t => new { t.BillID, t.ServiceID })
                .ForeignKey("dbo.Bills", t => t.Bill_billsID)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ServiceID)
                .Index(t => t.Bill_billsID);
            
            CreateTable(
                "dbo.DoctorSlots",
                c => new
                    {
                        DoctorID = c.Int(nullable: false),
                        SlotsID = c.Int(nullable: false),
                        isReserved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorID, t.SlotsID })
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .ForeignKey("dbo.Slots", t => t.SlotsID, cascadeDelete: true)
                .Index(t => t.DoctorID)
                .Index(t => t.SlotsID);
            
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        SlotsID = c.Int(nullable: false, identity: true),
                        day = c.String(),
                        slots_times = c.String(),
                    })
                .PrimaryKey(t => t.SlotsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorSlots", "SlotsID", "dbo.Slots");
            DropForeignKey("dbo.DoctorSlots", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.BillServices", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.BillServices", "Bill_billsID", "dbo.Bills");
            DropForeignKey("dbo.Bills", "billsID", "dbo.Visits");
            DropForeignKey("dbo.Prescriptions", "ID", "dbo.Visits");
            DropForeignKey("dbo.Visits", "Patient_ID", "dbo.Patients");
            DropForeignKey("dbo.Diagnoses", "DiagnosesID", "dbo.Visits");
            DropForeignKey("dbo.Visits", "Clinc_clinicID", "dbo.Clinics");
            DropForeignKey("dbo.Services", "Clinic_clinicID", "dbo.Clinics");
            DropForeignKey("dbo.Services", "Bills_billsID", "dbo.Bills");
            DropForeignKey("dbo.Reseptionests", "Usertypes_ID", "dbo.Users");
            DropForeignKey("dbo.Doctors", "UserTypes_ID", "dbo.Users");
            DropForeignKey("dbo.Doctors", "ClinicId", "dbo.Clinics");
            DropIndex("dbo.DoctorSlots", new[] { "SlotsID" });
            DropIndex("dbo.DoctorSlots", new[] { "DoctorID" });
            DropIndex("dbo.BillServices", new[] { "Bill_billsID" });
            DropIndex("dbo.BillServices", new[] { "ServiceID" });
            DropIndex("dbo.Prescriptions", new[] { "ID" });
            DropIndex("dbo.Diagnoses", new[] { "DiagnosesID" });
            DropIndex("dbo.Services", new[] { "Clinic_clinicID" });
            DropIndex("dbo.Services", new[] { "Bills_billsID" });
            DropIndex("dbo.Reseptionests", new[] { "Usertypes_ID" });
            DropIndex("dbo.Doctors", new[] { "UserTypes_ID" });
            DropIndex("dbo.Doctors", new[] { "ClinicId" });
            DropIndex("dbo.Visits", new[] { "Patient_ID" });
            DropIndex("dbo.Visits", new[] { "Clinc_clinicID" });
            DropIndex("dbo.Bills", new[] { "billsID" });
            DropTable("dbo.Slots");
            DropTable("dbo.DoctorSlots");
            DropTable("dbo.BillServices");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Patients");
            DropTable("dbo.Diagnoses");
            DropTable("dbo.Services");
            DropTable("dbo.Reseptionests");
            DropTable("dbo.Users");
            DropTable("dbo.Doctors");
            DropTable("dbo.Clinics");
            DropTable("dbo.Visits");
            DropTable("dbo.Bills");
        }
    }
}
