using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clinckDB.databaseclincik;

namespace Clicic
{
    public partial class PrescriptionAndDiagnosis : Form
    {
        public int VisitID { get; set; }
        public Doctor LoggedUser { get; set; }




        public PrescriptionAndDiagnosis()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrescriptionAndDiagnosis_Load(object sender, EventArgs e)
        {
            //textBox7.Text += LoggedUser.name;
        }
        Model1 context = new Model1();

        private void button1_Click(object sender, EventArgs e)
        {
            string[] row = new string[] { textBox1.Text, textBox2.Text, textBox4.Text, richTextBox1.Text };
            dataGridView1.Rows.Add(row);


            try
            {

                Prescription prescription = new Prescription()
                {

                    medicen_name = textBox1.Text,
                    Duration = textBox2.Text,
                    Dose = Convert.ToInt32(textBox4.Text)

                };

                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                richTextBox1.Clear();
            }
            catch
            {

            }
            //context.Prescriptions.Add(prescription);
            //context.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //Visit visit = new Visit() { };
            //            var visit = context.Visites.Where(v => v.visit_date = "07 / 03 / 2023").Select(i=>i.VisitID).FirstOrDefault();

            var visit = new Visit() { Diagnoses  = new Diagnoses() { DiagnosesID = 1, DiagnosesTxt = richTextBox2.Text } };
            Prescription prescription = new Prescription();
            context.Visites.Add(visit);
            //diagnoses.Visit.VisitID = 6;
            //context.Dignouses.Add(diagnoses);
            //    for (int i = 0; i < dataGridView1.Rows.Count-1; i++)x
            //    {
            //        prescription.Visit.VisitID = visit;
            //        prescription.medicen_name = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //        prescription.Duration = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //        prescription.Dose = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString());
            //        //prescription.instr = dataGridView1.Rows[i].Cells[3].Value.ToString();
            //        context.Prescriptions.Add(prescription);
            //        context.SaveChanges();
            ////    }
            ////}
            ////catch
            ////{

            //}
        }
    }
}
