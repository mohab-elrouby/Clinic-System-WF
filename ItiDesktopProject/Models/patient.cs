using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinckDB.databaseclincik
{
    public class Patient

    {

        public int ID { set; get; }
        [required]
        public string name { set; get; }
        [required]
        public string address { set; get; }
        public int? age { set; get; }
        public string phonnumber { set; get; }
        public string gender { set; get; }
        public string mirtal_status { set; get; }
        public string  Email  { set; get; }
        List<Visit> Visits { get; set; } = new List<Visit>();


    }
}
