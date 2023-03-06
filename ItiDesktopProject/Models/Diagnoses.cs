using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinckDB.databaseclincik
{
 public class Diagnoses
    {

        [Key]
        [ForeignKey("Visit")]
        public int DiagnosesID { set; get; }
        public string DiagnosesTxt { set; get; }
        public Visit Visit { set; get; }

    }
} 
