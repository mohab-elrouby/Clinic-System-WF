using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinckDB.databaseclincik
{
   public class Prescription
    {

        [Key]
        //[ForeignKey("Visit")]
        public int ID { set; get; }
        public string medicen_name { set; get; }
        public int? Dose { set; get; }
        public string Duration { set; get; }
        public string Instruction { set; get; }
        public Visit Visit { set; get; }

    }



}
