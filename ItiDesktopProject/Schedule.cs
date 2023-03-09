using clinckDB.databaseclincik;
using ItiDesktopProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicic
{
    public partial class Schedule : Form
    {
        string cellValue;

        public Doctor LoggedUser { get; set; }

        private Timer timer = new Timer();

        Model1 context = new Model1();
        public Schedule()
        {
            InitializeComponent();
            // Set up timer
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
            timer.Start();

            // Set initial value
            UpdateDateTimeLabel();


            string currDate = DateTime.Now.Date.ToString().Split(separator: ' ')[0];


            var query = from v in context.Visites
                        where v.visit_date == currDate        /////////&& visit_statuse.Confirmed  //"02/03/2023"
                        select new { PatientName = v.Patient.name, Appointment = v.visit_time };

            var results = query.ToList(); //// take(10)
            dataGridView1.DataSource = results /*context.Visites.ToList()*/;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update displayed date and time
            UpdateDateTimeLabel();
        }
        private void UpdateDateTimeLabel()
        {
            DateTime now = DateTime.Now;
            string formattedDateTime = now.ToString("dd/MM/yyyy hh:mm:ss");
            textBox2.Text = formattedDateTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MedicalHistory medicalHistory = new MedicalHistory();

            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];

                // Check if the selected cell's value is not null or empty
                if (selectedCell.Value != null && !string.IsNullOrEmpty(selectedCell.Value.ToString()))
                {
                    // Get the value of the selected cell as a string
                    string cellValue = selectedCell.Value.ToString();
                    medicalHistory.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Selected cell has no value.");
                }
            }
            else
            {
                MessageBox.Show("No cell is selected.");
            }
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            // var context = new Model1();
            // get logged doctor name 
            // textBox1.Text += LoggedUser.name;

            // var DoctorName1 = context.Doctors.Where(d => d.name == )
            if (dataGridView1.Rows.Count > 0)
            {
                this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
                this.dataGridView1.DefaultCellStyle.ForeColor = Color.White;
                this.dataGridView1.DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.MediumSeaGreen;
                this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 40; // Set header row height to 40 pixels

                //set default patient info to first one.
                MedicalHistory.SelelctedName = dataGridView1.Rows[0].Cells[0].Value.ToString();
                //    dataGridView2.AutoResizeRow  ;
                dataGridView1.Height = (dataGridView1.RowCount + 2) * dataGridView1.RowTemplate.Height;
                // set inital value to medicalhistory 2 proparty name & id on load
                DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
                string cellValue = selectedCell.Value.ToString();
                MedicalHistory.SelelctedName = cellValue;
                var GetPatientID = context.Patients.Where(p => p.name == cellValue).Select(p => p.ID).FirstOrDefault();
                MedicalHistory.SelelctedPatientID = GetPatientID;
            }
            else
            {
                button1.Enabled = false;
                dataGridView1.Visible = false;

            }

            // textBox1.Text = "Doctor : " + DoctorName;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
                string cellValue = selectedCell.Value.ToString();
                MedicalHistory.SelelctedName = cellValue;
                var GetPatientID = context.Patients.Where(p => p.name == cellValue).Select(p => p.ID).FirstOrDefault();
                MedicalHistory.SelelctedPatientID = GetPatientID;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {

                dataGridView1[e.ColumnIndex, e.RowIndex].Selected = false;
                dataGridView1[0, e.RowIndex].Selected = true;
                var value = dataGridView1[0, e.RowIndex].Value.ToString();
                MedicalHistory.SelelctedName = value;
                var GetPatientID = context.Patients.Where(p => p.name == value).Select(p => p.ID).FirstOrDefault();
                MedicalHistory.SelelctedPatientID = GetPatientID;

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].Selected = false;
                dataGridView1[0, e.RowIndex].Selected = true;
                var value = dataGridView1[0, e.RowIndex].Value.ToString();

                MedicalHistory.SelelctedName = value;
                ////////
                var GetPatientID = context.Patients.Where(p => p.name == value).Select(p => p.ID).FirstOrDefault();
                MedicalHistory.SelelctedPatientID = GetPatientID;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //  dataGridView1.ColumnHeaderMouseClick 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrescriptionAndDiagnosis prescriptionAndDiagnosis = new PrescriptionAndDiagnosis();
            prescriptionAndDiagnosis.VisitID = context.Visites.Where(p => p.Patient.name == cellValue).Select(p => p.VisitID).FirstOrDefault();
            prescriptionAndDiagnosis.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServicesBill servicesBill = new ServicesBill();
            servicesBill.ShowDialog();
        }
    }
}
