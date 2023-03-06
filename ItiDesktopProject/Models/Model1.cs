using System;
using System.Data.Entity;
using System.Linq;

namespace clinckDB.databaseclincik
{
    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'clinckDB.databaseclincik.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
      public virtual DbSet<Clinic> Clincs { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Reseptionest> Reseptionests { get; set; }
        public virtual DbSet<User> Usertypes { get; set; }
        public virtual DbSet<Visit> Visites { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
       public virtual DbSet<Diagnoses> Dignouses { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Slots> Slots { get; set; }
        public virtual DbSet<BillServices> BillServices { get; set; }

     public virtual DbSet<DoctorSlots>Doctor_Slots{ get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}