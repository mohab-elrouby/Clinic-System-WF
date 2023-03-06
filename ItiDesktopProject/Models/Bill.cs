using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinckDB.databaseclincik
{
    public class Bill
    {

        [Key]
        [ForeignKey("Visit")]
        public int billsID { set; get; }
        [required]
        public int totalCost { set; get; }
        public Visit Visit { set; get; }
        public DateTime Date { get; set; }
        List<Services> Services { set; get; } = new List<Services>();

    }
}
