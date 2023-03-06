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
            

            context.Clincs.AddOrUpdate(new Clinic() { clinic_name = "Card", start_time = "9am", end_time="9pm" });
            context.Clincs.AddOrUpdate(new Clinic() { clinic_name = "ENT", start_time = "9am", end_time="9pm" });
            context.Clincs.AddOrUpdate(new Clinic() { clinic_name = "Dental", start_time = "9am", end_time="9pm" });


            context.Doctors.AddOrUpdate(new Doctor() { name = "Ahmed mohamed", Email = "ahmed@gmail.com", age = 30, ClinicId = 1, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { name = "Bahaa mohamed", Email = "bahaa@gmail.com", age = 33, ClinicId = 1, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { name = "Youssef mohamed", Email = "youssef@gmail.com", age = 40, ClinicId = 1, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { name = "Khaled mohamed", Email = "khaled@gmail.com", age = 29, ClinicId = 2, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { name = "Sara mohamed", Email = "sara@gmail.com", age = 31, ClinicId = 2, Gender = "Female", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { name = "Hanaa mohamed", Email = "hanaa@gmail.com", age = 30, ClinicId = 2, Gender = "Female", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { name = "Ali mohamed", Email = "ali@gmail.com", age = 30, ClinicId = 3, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { name = "Alaa mohamed", Email = "alaa@gmail.com", age = 35, ClinicId = 3, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });
            context.Doctors.AddOrUpdate(new Doctor() { name = "Mostafa mohamed", Email = "mostafa@gmail.com", age = 42, ClinicId = 3, Gender = "Male", Mirtal_Status = "Single", phonNumber = "01125374645", percentage = 40f, Contract ="", AccountantEmail = "" });



            context.Patients.AddOrUpdate(new Patient() { name = "Ali hamada", age = 32, Email = "ali@gmail.com", address="new cairo", gender = "Male", mirtal_status = "Single", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { name = "Youssef fawzy", age = 30, Email = "youssef@gmail.com", address="giza", gender = "Male", mirtal_status = "Married", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { name = "Ahmed gad", age = 22, Email = "ahmedgad@gmail.com", address="6th october", gender = "Male", mirtal_status = "Single", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { name = "Mohamed Salah", age = 52, Email = "mohamed@gmail.com", address="fayoum", gender = "Male", mirtal_status = "Married", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { name = "Nasser hady", age = 28, Email = "nasser@gmail.com", address="alex", gender = "Male", mirtal_status = "Single", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { name = "Fady sayed", age = 38, Email = "fady@gmail.com", address="doki", gender = "Male", mirtal_status = "Married", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { name = "Noor mostafa", age = 24, Email = "noor@gmail.com", address="zayed", gender = "female", mirtal_status = "Single", phonnumber = "01024537272" });
            context.Patients.AddOrUpdate(new Patient() { name = "Huda Ali", age = 32, Email = "huda@gmail.com", address="nasr city", gender = "Female", mirtal_status = "Married", phonnumber = "01024537272" });


            for (int i = 0; i < 7; i++)
            {
                for (int j = 1; j <= 24; j++)
                {
                    context.Slots.AddOrUpdate(new Slots() { day = "day"+i, slots_times = j.ToString() });
                }
            }

            for (int j = 1; j <= context.Slots.Select(s=>s.SlotsID).Count(); j++)
            {
                for (int i = 1; i <= context.Doctors.Select(d=>d.doctorID).Count(); i++)
                {
                    context.Doctor_Slots.AddOrUpdate(new DoctorSlots() { DoctorID = i, SlotsID = j, isReserved = false });
                }
            }

            context.Services.AddOrUpdate(new Services() { servcsesname = "Cnsultation", cost=1300 });
            context.Services.AddOrUpdate(new Services() { servcsesname = "Botox injection", cost=6500 });
            context.Services.AddOrUpdate(new Services() { servcsesname = "Botox underarm", cost=7800 });
            context.Services.AddOrUpdate(new Services() { servcsesname = "Filler injection", cost=6500 });
            context.Services.AddOrUpdate(new Services() { servcsesname = "Hips dips", cost=6500 });
            context.Services.AddOrUpdate(new Services() { servcsesname = "Profihlo", cost=9100 });
            context.Services.AddOrUpdate(new Services() { servcsesname = "Burn", cost=1950 });
            context.Services.AddOrUpdate(new Services() { servcsesname = "Fingertip", cost=6500 });
            context.Services.AddOrUpdate(new Services() { servcsesname = "Stature", cost=6500 });

            context.SaveChanges();

        }
    }
}
