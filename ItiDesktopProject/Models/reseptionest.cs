using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinckDB.databaseclincik
{
 public class Reseptionest
    {
        public int Id { get; set; }
        [required]
        public string name { set; get; }
        [required]

        public string adress { set; get; }

        public  int age { set; get; }
        public int phonnumber { set; get; }
        public string gender { set; get; }
        [required]

        public string mirtal_status { set; get; }
        public string Email { set; get; }
        [required]

        public string hiringdate { set; get; }
        [required]

        float salary { set; get; }
        public User Usertypes { set; get; }



    }

    internal class requiredAttribute : Attribute
    {
    }
}
