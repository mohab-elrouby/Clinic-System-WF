using clinckDB.databaseclincik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItiDesktopProject
{
    public partial class MakeReservationForm : Form
    {
        Model1 model1 = new Model1();
        IList<Visit> visits;
        IList<Clinic> allClinics;
        IList<Doctor> allDoctors;
        IList<string> days;
        ConfirmReservation confirmReservation;


        int selectedIndex = 0;

        string currDate = DateTime.Now.Date.ToString().Split(separator: ' ')[0];
        Dictionary<string, string> daysDict = new Dictionary<string, string>(){
            {"day0", "Sun"},
            {"day1", "Mon"},
            {"day2", "Tue"},
            {"day3", "Wed"},
            {"day4", "Thu"},
            {"day5", "Fri"},
            {"day6", "Sat"}
        };
        public MakeReservationForm()
        {
            InitializeComponent();
        }



        private void MakeReservationForm_Load(object sender, EventArgs e)
        {
            allClinics= model1.Clincs.Select(c => c).ToList();
            comboBox1.Items.AddRange(allClinics.Select(c => c.clinic_name).ToArray());
            comboBox1.SelectedIndex = 0;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex= comboBox1.SelectedIndex;
            dataGridView1.Rows.Clear();
            allDoctors = model1.Doctors.Where(d => d.ClinicId == selectedIndex+1).ToList();
            for (int i = 0; i < allDoctors.Count; i++)
            {
                int docId = allDoctors[i].doctorID;
                string daysStr ="";
                var days = model1.Doctor_Slots.Include("Slots").Where(d => d.DoctorID == docId).Select(d => d.Slots.day).Distinct().ToList();
                int j ;
                for (j = 0; j < days.Count-1; j++)
                {
                    daysStr += daysDict[days[j]]+ " - ";
                }
                daysStr += daysDict[days[j]];
                dataGridView1.Rows.Add(allDoctors[i].name, daysStr, allDoctors[i].WorkingHours, allDoctors[i].phonNumber, "", allDoctors[i].Email);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Get the value of the selected cell
                DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];

                // Check if the selected cell's value is not null or empty
                if (selectedCell.Value != null && !string.IsNullOrEmpty(selectedCell.Value.ToString()))
                {
                    // Get the value of the selected cell as a string

                    string cellValue = selectedCell.Value.ToString();
                    confirmReservation = new ConfirmReservation();
                    int index = dataGridView1.SelectedRows[0].Index;
                    confirmReservation.docID = allDoctors[index];
                    confirmReservation.clinicID = allClinics[index];
                    confirmReservation.Show();
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
    }
}
