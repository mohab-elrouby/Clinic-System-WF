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
using clinckDB.databaseclincik;


namespace Clicic
{
    public partial class ServicesBill : Form
    {
        Model1 context = new Model1();
        public Doctor LoggedUser { get; set; }
        public ServicesBill()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ServicesBill_Load(object sender, EventArgs e)
        {
            LoggedUser.name = "Khaled";
            textBox7.Text += LoggedUser.name;
            string ServiceName = context.Services.Where(c => c.Clinic == LoggedUser.Clinic).Select(i => i.servcsesname).FirstOrDefault();
            float ServiceCost = context.Services.Where(c => c.Clinic == LoggedUser.Clinic).Select(i => i.cost).FirstOrDefault();
            LoggedUser.Clinic = context.Clincs.Where(c => c.clinicID == 4).FirstOrDefault();
            label4.Text = Convert.ToString(LoggedUser.Clinic.clinicID);
            //textBox6.Text = 
        }
    }
}
