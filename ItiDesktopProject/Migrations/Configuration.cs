namespace ItiDesktopProject.Migrations
{
    using clinckDB.databaseclincik;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<clinckDB.databaseclincik.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(clinckDB.databaseclincik.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE Visits");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE Clinics");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE Doctors");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE Patients");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE Slots");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE DoctorSlots");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE Services");

            context.Visites.RemoveRange(context.Visites);
            context.Clincs.RemoveRange(context.Clincs);
            context.Doctors.RemoveRange(context.Doctors);
            context.Patients.RemoveRange(context.Patients);
            context.Slots.RemoveRange(context.Slots);
            context.Doctor_Slots.RemoveRange(context.Doctor_Slots);
            context.Services.RemoveRange(context.Services);

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('ClinicDb.dbo.Visits', RESEED, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('ClinicDb.dbo.Clinics', RESEED, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('ClinicDb.dbo.Doctors', RESEED, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('ClinicDb.dbo.Patients', RESEED, 0)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('ClinicDb.dbo.Slots', RESEED, 0)");
            //context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('ClinicDb.dbo.DoctorSlots', RESEED, 1)");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('ClinicDb.dbo.Services', RESEED, 0)");


            context.SaveChanges();
            context.Clincs.AddOrUpdate(new Clinic() { clinicID =1, clinic_name = "Card", start_time = "9am", end_time="9pm" });
            context.Clincs.AddOrUpdate(new Clinic() { clinicID =2, clinic_name = "ENT", start_time = "9am", end_time="9pm" });
            context.Clincs.AddOrUpdate(new Clinic() { clinicID =3, clinic_name = "Dental", start_time = "9am", end_time="9pm" });

            context.Doctors.AddOrUpdate(new Doctor() { doctorID = 1, name = "Ahmed mohamed", Email = "ahmed@gmail.com", age = 30, ClinicId = 1, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { doctorID = 2, name = "Bahaa mohamed", Email = "bahaa@gmail.com", age = 33, ClinicId = 1, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { doctorID = 3, name = "Youssef mohamed", Email = "youssef@gmail.com", age = 40, ClinicId = 1, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { doctorID = 4, name = "Khaled mohamed", Email = "khaled@gmail.com", age = 29, ClinicId = 2, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { doctorID = 5, name = "Sara mohamed", Email = "sara@gmail.com", age = 31, ClinicId = 2, Gender = "Female", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { doctorID = 6, name = "Hanaa mohamed", Email = "hanaa@gmail.com", age = 30, ClinicId = 2, Gender = "Female", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { doctorID = 7, name = "Ali mohamed", Email = "ali@gmail.com", age = 30, ClinicId = 3, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { doctorID = 8, name = "Alaa mohamed", Email = "alaa@gmail.com", age = 35, ClinicId = 3, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { doctorID = 9, name = "Mostafa mohamed", Email = "mostafa@gmail.com", age = 42, ClinicId = 3, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });


            context.Patients.AddOrUpdate(new Patient() { ID = 1, name = "Ali hamada", age = 32, Email = "ali@gmail.com", address="new cairo", gender = "Male", mirtal_status = "Single", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { ID = 2, name = "Youssef fawzy", age = 30, Email = "youssef@gmail.com", address="giza", gender = "Male", mirtal_status = "Married", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { ID = 3, name = "Ahmed gad", age = 22, Email = "ahmedgad@gmail.com", address="6th october", gender = "Male", mirtal_status = "Single", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { ID = 4, name = "Mohamed Salah", age = 52, Email = "mohamed@gmail.com", address="fayoum", gender = "Male", mirtal_status = "Married", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { ID = 5, name = "Nasser hady", age = 28, Email = "nasser@gmail.com", address="alex", gender = "Male", mirtal_status = "Single", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { ID = 6, name = "Fady sayed", age = 38, Email = "fady@gmail.com", address="doki", gender = "Male", mirtal_status = "Married", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { ID = 7, name = "Noor mostafa", age = 24, Email = "noor@gmail.com", address="zayed", gender = "female", mirtal_status = "Single", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { ID = 8, name = "Huda Ali", age = 32, Email = "huda@gmail.com", address="nasr city", gender = "Female", mirtal_status = "Married", phonnumber = "01024537272" });


            for (int i = 0; i < 7; i++)
            {
                for (int j = 1; j <= 24; j++)
                {
                    context.Slots.AddOrUpdate(new Slots() { day = "day"+i, slots_times = j.ToString() });
                }
            }
            context.SaveChanges();

            for (int j = 1; j <= context.Slots.Select(s => s.SlotsID).Count(); j++)
            {
                for (int i = 1; i <= context.Doctors.Select(d => d.doctorID).Count(); i++)
                {
                    context.Doctor_Slots.AddOrUpdate(new DoctorSlots() { DoctorID = i, SlotsID = j, isReserved = false });
                }
            }
            context.Services.AddOrUpdate(new Services() { ID = 1, servcsesname = "Cnsultation", cost=1300 });
            context.Services.AddOrUpdate(new Services() { ID = 2, servcsesname = "Botox injection", cost=6500 });
            context.Services.AddOrUpdate(new Services() { ID = 3, servcsesname = "Botox underarm", cost=7800 });
            context.Services.AddOrUpdate(new Services() { ID = 4, servcsesname = "Filler injection", cost=6500 });
            context.Services.AddOrUpdate(new Services() { ID = 5, servcsesname = "Hips dips", cost=6500 });
            context.Services.AddOrUpdate(new Services() { ID = 6, servcsesname = "Profihlo", cost=9100 });
            context.Services.AddOrUpdate(new Services() { ID = 7, servcsesname = "Burn", cost=1950 });
            context.Services.AddOrUpdate(new Services() { ID = 8, servcsesname = "Fingertip", cost=6500 });
            context.Services.AddOrUpdate(new Services() { ID = 9, servcsesname = "Stature", cost=6500 });

            IList<Patient> patients = context.Patients.Select(p => p).ToList();
            context.Visites.AddOrUpdate(new Visit() { VisitID = 1, DoctorId = 1, PatientID = 1, visit_date = DateTime.Now.Date.ToString().Split(' ')[0], visit_time = "12:00", Visit_Status = visit_statuse.Confirmed, Clinc=context.Clincs.Find(1) });
            context.Visites.AddOrUpdate(new Visit() { VisitID = 2, DoctorId = 2, PatientID = 2, visit_date = DateTime.Now.Date.ToString().Split(' ')[0], visit_time = "12:30", Visit_Status = visit_statuse.Confirmed, Clinc=context.Clincs.Find(1) });
            context.Visites.AddOrUpdate(new Visit() { VisitID = 3, DoctorId = 3, PatientID = 3, visit_date = DateTime.Now.Date.ToString().Split(' ')[0], visit_time = "12:00", Visit_Status = visit_statuse.Confirmed, Clinc = context.Clincs.Find(1) });
            context.Visites.AddOrUpdate(new Visit() { VisitID = 4, DoctorId = 4, PatientID = 4, visit_date = DateTime.Now.Date.ToString().Split(' ')[0], visit_time = "12:30", Visit_Status = visit_statuse.Confirmed, Clinc = context.Clincs.Find(1) });
            context.Visites.AddOrUpdate(new Visit() { VisitID = 5, DoctorId = 5, PatientID = 5, visit_date = DateTime.Now.Date.ToString().Split(' ')[0], visit_time = "12:00", Visit_Status = visit_statuse.Confirmed, Clinc = context.Clincs.Find(1) });
            context.Visites.AddOrUpdate(new Visit() { VisitID = 6, DoctorId = 6, PatientID = 6, visit_date = DateTime.Now.Date.ToString().Split(' ')[0], visit_time = "12:30", Visit_Status = visit_statuse.Confirmed, Clinc = context.Clincs.Find(1) });

            context.SaveChanges();

        }
    }
}
