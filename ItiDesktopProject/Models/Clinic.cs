using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinckDB.databaseclincik
{
  public class Clinic
    {
      
        public int clinicID { set; get; }

        [required]
        public string clinic_name { set; get; }
        public string start_time { set; get; }
        public string end_time { set; get; }

        public List<Doctor> Doctors { set; get; } = new List<Doctor>();
        public List<Visit> Visits { set; get; } = new List<Visit>();
        public List<Services> Services { set; get; } = new List<Services>();




    }
}
