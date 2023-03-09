using clinckDB.databaseclincik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItiDesktopProject
{
    public partial class ReceptionistAppointmentsForm : Form
    {
        Model1 model1 = new Model1();
        public Reseptionest LoggedUser { get; set; }
        IList<Visit> visits;
        IList<Visit> allVisits;
        IList<string> payment = new List<string>() { "Paid", "Unpaid"};
        IList<string> appointment = new List<string>() { "Confirmed", "Done", "Cancelled"};
        string currDate = DateTime.Now.Date.ToString().Split(separator: ' ')[0];

        public ReceptionistAppointmentsForm()
        {
            InitializeComponent();
        }

        private void ReceptionistAppointmentsForm_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            visits = model1.Visites.Include("Clinc").Include("Patient").Include("Doctor").Where(v => v.visit_date == currDate).Select(v => v).ToList();
            for (int i = 0; i < visits.Count; i++)
            {
                dataGridView1.Rows.Add(visits[i].Patient.name, visits[i].Doctor.name, visits[i].Clinc.clinic_name, visits[i].visit_time, "", "");
                dataGridView1.Rows[i].Tag= visits[i].VisitID;
                if (visits[i].Visit_Status == visit_statuse.Done) 
                {
                    dataGridView1.Rows[i].ReadOnly = true;
                };
            }
            PaymentStatusCol.DataSource = payment;
            AppointmentStatusCol.DataSource = appointment;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new MakeReservationForm();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var tem= dataGridView1.Rows[e.RowIndex].Tag;
            var visitDetails = new VisitDetails();
            visitDetails.VisitId = (int)tem;
            visitDetails.Closed += (s, args) => this.Close();
            visitDetails.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form2 = new MakeReservationForm();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
