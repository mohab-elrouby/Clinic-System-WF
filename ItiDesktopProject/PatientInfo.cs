using Clicic;
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
    public partial class PatientInfo : Form
    {
        public static string SelelctedName { get; set; }

        public PatientInfo()
        {
            Model1 context = new Model1();
            InitializeComponent();
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(61, 168, 125);
            //   headerStyle.ForeColor = Color.White;

            dataGridView1.ColumnCount = 6;
            dataGridView1.RowTemplate.Height = 35;
            //dataGridView1.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(61, 168, 125);
            //dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.White;

            dataGridView1.Columns[0].Name = "Patient Name";
            dataGridView1.Columns[1].Name = "Phone ";
            dataGridView1.Columns[2].Name = "Email";
            dataGridView1.Columns[3].Name = "Gender";
            dataGridView1.Columns[4].Name = "Age";
            dataGridView1.Columns[5].Name = "Marital Status";
            dataGridView1.Columns[0].Width = 200;

            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].Width = 220;
            dataGridView1.Columns[3].Width = 210;
            dataGridView1.Columns[4].Width = 210;
            dataGridView1.Columns[5].Width = 210;
            Schedule x = new Schedule();


            //this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 30);
            //string[] row = new string[] { "1", "Product 1", "1000" };
            var query = context.Patients.Where(p => p.name == SelelctedName /* Id from other form */).Select(p => p).FirstOrDefault();

            string[] row = new string[] { query.name, query.phonnumber.ToString(), query.Email, query.gender, query.age.ToString(), query.mirtal_status };
            dataGridView1.Rows.Add(row);

        }

        private void PatientInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = 40; // Set header row height to 40 pixels
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(61, 168, 125);
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 15);
        }
    }
}
