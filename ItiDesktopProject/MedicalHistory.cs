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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clicic
{
    public partial class MedicalHistory : Form
    {
        public static string SelelctedName { get; set; }
        public static int SelelctedPatientID { get; set; }

        Model1 context = new Model1();
        private Timer timer = new Timer();
        public MedicalHistory()
        {
            InitializeComponent();
            // Model1 context = new Model1();
            // Set up timer
            timer.Interval = 1000; // 1 second
            timer.Tick += timer1_Tick;
            timer.Start();

            // Set initial value
            UpdateDateTimeLabel();

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(61, 168, 125);
            //   headerStyle.ForeColor = Color.White;

            dataGridView1.ColumnCount = 6;
            dataGridView1.RowTemplate.Height = 35;
            //dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(61, 168, 125);
            //dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.White;

            dataGridView1.Columns[0].Name = "Doctor";
            dataGridView1.Columns[1].Name = "Clinic ";
            dataGridView1.Columns[2].Name = "Date";
            // dataGridView1.Columns[3].Name = "Payment Stauts";
            //     dataGridView1.Columns[4].Name = "Payment Method";
            dataGridView1.Columns[3].Name = "Appointment Status";
            dataGridView1.Columns[4].Width = 200;

            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].Width = 220;
            dataGridView1.Columns[3].Width = 210;
            dataGridView1.Columns[4].Width = 210;
            //  dataGridView1.Columns[5].Width = 210;
            Schedule x = new Schedule();


            //this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 30);
            //string[] row = new string[] { "1", "Product 1", "1000" };

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
            //    string cellValue = selectedCell.Value.ToString();
            //   // PatientInfo.SelelctedName = cellValue;
            //}
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            VisitDetails visitDetails = new VisitDetails();
            //dataGridView1.Rows[0].Cells[0].Value.ToString();
            //visitDetails.VisitId = dataGridView1[0, e.RowIndex].Value.ToString();

            visitDetails.ShowDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void MedicalHistory_Load(object sender, EventArgs e)
        {

            textBox3.Text = $"Patient : {SelelctedName}";
            //var VisitedInfoQuery = context.Visites.Where(v=>v.PatientID == SelelctedPatientID).Select(v=>v)
            var VisitedInfoQuery = from v in context.Visites
                                   where v.PatientID == SelelctedPatientID && v.Visit_Status == visit_statuse.Done
                                   select new { Doctor = v.Doctor.name, Clinic = v.Clinc.clinic_name, Date = v.visit_date, AppointmetStauts = v.Visit_Status };
            // var query = context.Patients.Where(p => p.name == SelelctedName /* Id from other form */).Select(p => p).FirstOrDefault();
            foreach (var item in VisitedInfoQuery)
            {
                //if(item != null)
                //{
                string[] row = new string[] { item.Doctor, item.Clinic, item.Date, item.AppointmetStauts.ToString() };
                dataGridView1.Rows.Add(row);
                //}
                //MessageBox.Show("No Medical History for this Patient.");
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 15);
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            this.dataGridView1.DefaultCellStyle.BackColor = Color.MediumSeaGreen;
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.MediumSeaGreen;
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = 40; // Set header row height to 40 pixels
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(61, 168, 125);


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex > 0)
            //{
            //    dataGridView1[e.ColumnIndex, e.RowIndex].Selected = false;
            //    dataGridView1[0, e.RowIndex].Selected = true;
            //}
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //    if (dataGridView1.SelectedRows.Count == 0) return;
            //    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;
        }
    }
}
