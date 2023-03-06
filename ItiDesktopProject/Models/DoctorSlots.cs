using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinckDB.databaseclincik
{
    public class DoctorSlots
    {
        [Key, Column(Order = 2)]
        public int SlotsID { get; set; }
        public Slots Slots { get; set; }

        [Key, Column(Order = 1)]
        public int DoctorID { set; get; }
        public Doctor Doctor { get; set; }
        public bool isReserved
        {
            set;
            get;
        } = false;
    }
}
