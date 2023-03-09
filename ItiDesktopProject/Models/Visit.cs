using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace clinckDB.databaseclincik
{
    [Flags]
    public enum visit_statuse :byte
    {

       Done =1,
       Confirmed  =2,
       Cancelled =4


    }
    public class Visit 
    {
        public int VisitID { set; get; }
        public visit_statuse Visit_Status { get; set; }
        public string visit_date { set; get; }
        public string visit_time { set; get; }
        public Clinic Clinc { set;get; }
        public Bill Bills { set; get; }
        public int PatientID { set; get; }
        public Patient Patient { set; get; }
        public int DoctorId { set; get; }
        public Doctor Doctor { set; get; }
        public List<Prescription> Prescription { set; get; }
        public Diagnoses Diagnoses { get; set; }
    }
}
