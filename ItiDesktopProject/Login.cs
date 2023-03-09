using Clicic;
using clinckDB.databaseclincik;
using clinckDB.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItiDesktopProject

{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            List<clinckDB.databaseclincik.User> users = new List<User> { };
            clinckDB.databaseclincik.Model1 context = new Model1();
            users = context.Usertypes.Select(n => n).ToList();
            #region Forms Creation
            ReceptionistAppointmentsForm receptionistAppointmentsForm = new ReceptionistAppointmentsForm();
            Adminstrator admin = new Adminstrator();
            Schedule schedule = new Schedule();
            ConfirmReservation confirmReservation = new ConfirmReservation();
            ServicesBill servicesBill = new ServicesBill();
            PrescriptionAndDiagnosis prescriptionAndDiagnosis = new PrescriptionAndDiagnosis();
            #endregion

            User user = context.Usertypes.Where(u => u.UserName == usernameTxt.Text).SingleOrDefault();
            //string name = context.Usertypes.Where(u => u.ID == user.ID).Select(n);
            if (user != null)
            {
                if (user.Password == passwordTxt.Text)
                {
                    if (user.type == "R")
                    {
                        receptionistAppointmentsForm.LoggedUser = context.Reseptionests.Where(u => u.Usertypes.ID == user.ID).Select(n => n).SingleOrDefault();
                        receptionistAppointmentsForm.Show();
                        this.Hide();
                    }
                    else if (user.type == "D")
                    {
                        schedule.LoggedUser = context.Doctors.Where(u => u.UserTypes.ID == user.ID).Select(n => n).SingleOrDefault();
                        prescriptionAndDiagnosis.LoggedUser = schedule.LoggedUser;
                        servicesBill.LoggedUser = schedule.LoggedUser;
                        schedule.Show();
                        this.Hide();
                    }
                    else
                    {
                        admin.Show();
                        this.Hide();
                    }
                }
                else
                {
                    label1.Text = "Wrong Info";
                    label1.Visible = true;
                }

            }
            else
            {
                label1.Text = "Wrong Info";
                label1.Visible = true;
            }


        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }
    }
}
/*
 * Doctor
 * -----
 * Schedule
 * Prescription & Diagnosis
 * ServiceBill
 *
 *Receptionist
 *
 *ReceptionistAppointmentForm
 */
