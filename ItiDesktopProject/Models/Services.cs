using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace clinckDB.databaseclincik
{
    public class Services
    {

        public int ID { set; get; }
        [required]
         public string servcsesname { set; get; }

        public float cost { set; get; }

        public Clinic Clinic { set; get; }
        public Bill Bills { set; get; }

    }
}
