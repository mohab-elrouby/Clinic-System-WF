using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinckDB.databaseclincik
{
   public class User
    {
        public int ID { get; set; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string type { set; get; }
        public List<Doctor> Doctors { set; get; } = new List<Doctor>();
        public List<Reseptionest> reseptionests { set; get; } = new List<Reseptionest>();
    }
}
