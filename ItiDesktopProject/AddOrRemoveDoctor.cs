using clinckDB.databaseclincik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ItiDesktopProject
{

    public partial class AddOrRemoveDoctor : Form
    {
        Model1 context = new Model1();
        public AddOrRemoveDoctor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrRemoveReceptionist addOrRemoveReceptionist = new AddOrRemoveReceptionist();
            addOrRemoveReceptionist.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Adminstrator adminstrator = new Adminstrator();
            adminstrator.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Doctor doctor = new Doctor();
            try
            {
                doctor.name = FullName.Text;
                doctor.age = Convert.ToInt32(age.Text);
                //doctor.percentage = Convert.T(Percentage.Text);
                doctor.AccountantEmail = AccEmail.Text;
                doctor.Clinic.clinicID = Convert.ToInt32(Clinic.Text);
                doctor.Contract = Contract.Text;
                doctor.Email = DocEmail.Text;
                doctor.Gender = gender.Text;
                doctor.Mirtal_Status = Mirtal.Text;
                doctor.phonNumber = Phone.Text;
                doctor.UserTypes.ID = Convert.ToInt32(UserID.Text);
                //doctor.Address = Address.Text;
            }
            catch
            {

            }

            context.Doctors.Add(doctor);
            FullName.Clear();
            age.Clear();
            Percentage.Clear();
            AccEmail.Clear();
            Clinic.Clear();
            Contract.Clear();
            DocEmail.Clear();
            Phone.Clear();

            Address.Clear();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddOrRemoveDoctor_Load(object sender, EventArgs e)
        {
            var users = context.Usertypes.Select(u => u.UserName).ToArray();
            UserID.Items.AddRange(users);
        }
    }
}
