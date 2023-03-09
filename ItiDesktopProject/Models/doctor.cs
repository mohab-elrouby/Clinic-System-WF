using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinckDB.databaseclincik
{
   public class Doctor
    {


        [key]
        //[ForeignKey("Clinic")]
        public int doctorID { set; get; }
        [required]
        public string name { set; get; }

        public int age { set; get; }

        public float percentage { set; get; }
        public string phonNumber { set; get; }
        [required]
        public string Gender { set; get; }
        [required]
        public string Mirtal_Status { set; get; }
        [required]
        public string Email { set; get; }
        [required]
        public string AccountantEmail { set; get; }
        [required]
        public string Contract { set; get; }
        public Clinic Clinic { set; get; }
        public int ClinicId { get; set; }

        public User UserTypes { set; get; }
        List<DoctorSlots> Doctor_Slots { set; get; } = new List<DoctorSlots>();

        public string WorkingHours { set; get; }





    }
}
