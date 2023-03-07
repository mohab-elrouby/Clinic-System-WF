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
    public partial class MakeReservationForm : Form
    {
        Model1 model1 = new Model1();
        IList<Visit> visits;
        IList<Clinic> allClinics;
        IList<Doctor> allDoctors;
        int selectedIndex =0;

        string currDate = DateTime.Now.Date.ToString().Split(separator: ' ')[0];
        public MakeReservationForm()
        {
            InitializeComponent();
        }



        private void MakeReservationForm_Load(object sender, EventArgs e)
        {
            allClinics= model1.Clincs.Select(c => c).ToList();
            comboBox1.Items.AddRange(allClinics.Select(c => c.clinic_name).ToArray());
            if(selectedIndex == 0)
            {
                allDoctors = model1.Doctors.Select(c => c).ToList();
                for (int i = 0; i < allDoctors.Count; i++)
                {
                    dataGridView1.Rows.Add(allDoctors[i].name);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex= comboBox1.SelectedIndex;
            dataGridView1.Rows.Clear();
            allDoctors = model1.Doctors.Where(d => d.ClinicId == selectedIndex+1).ToList();
            for (int i = 0; i < allDoctors.Count; i++)
            {
                dataGridView1.Rows.Add(allDoctors[i].name);
            }
        }
    }
}
