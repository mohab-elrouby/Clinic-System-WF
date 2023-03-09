using clinckDB.databaseclincik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItiDesktopProject
{
    public partial class VisitDetails : Form
    {
        public int VisitId { private get; set; }
        Model1 model1 = new Model1();
        Diagnosis diagnosis;
        Bill bill;
        Prescription prescription;
        public Visit visit;
        public VisitDetails()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            diagnosis = (diagnosis != null)? diagnosis : new Diagnosis();
            diagnosis.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            prescription = (prescription != null) ? prescription : new Prescription();
            prescription.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bill = (bill != null) ? bill : new Bill();
            bill.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var receptionistAppointmentsForm = new ReceptionistAppointmentsForm();
            receptionistAppointmentsForm.Closed += (s, args) => this.Close();
            receptionistAppointmentsForm.Show();
            this.Hide();
        }

        private void VisitDetails_Load(object sender, EventArgs e)
        {
            visit = model1.Visites.Include("Clinc").Include("Patient").Include("Doctor").Include("Bills").Include("Prescription").Include("Diagnoses").Where(v=>v.VisitID == VisitId).FirstOrDefault();
            nameLable.Text += visit.Patient.name;
            doctorLable.Text += visit.Doctor.name;
            dateLable.Text += visit.visit_date;
            clinicLable.Text += visit.Clinc.clinic_name;
            visitStatusLable.Text += visit.Visit_Status;
            //dataGridView1.Rows.Add(visit.Patient.name, visit.Doctor.name, visit.Clinc.clinic_name, visit.visit_time, "", "", visit.Visit_Status);
        }
    }
}
