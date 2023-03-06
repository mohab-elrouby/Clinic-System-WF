using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinckDB.databaseclincik
{
    public class Slots
    {
       
        public int SlotsID { get; set; }
        public string day { get; set; }
        public string slots_times { get; set; }
        List<DoctorSlots> Doctor_Slots { set; get; } = new List<DoctorSlots>();


    }
}
