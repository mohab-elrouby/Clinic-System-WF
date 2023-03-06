using Clicic;
using clinckDB.databaseclincik;
using clinckDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItiDesktopProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //clinicRepository.Delete(2);
            //foreach (var item in clinicRepository.GetAll())
            //{
            //    Console.WriteLine(item.clinic_name);
            //}
            
            //Console.ReadLine();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new ConfirmReservation());
            //Application.Run(new MakeReservationForm());
            //Application.Run(new ReceptionistAppointmentsForm());
            //Application.Run(new Schedule());
            //Application.Run(new PrescriptionAndDiagnosis());
            //Application.Run(new ServicesBill());
            //Application.Run(new Adminstrator());
            //Application.Run(new MedicalHistory());
            //Application.Run(new VisitDetails());
            //Application.Run(new BIll());



        }
    }
}
