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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ItiDesktopProject
{
    public partial class AddOrRemoveReceptionist : Form
    {
        Model1 context = new Model1();

        public AddOrRemoveReceptionist()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddOrRemoveDoctor addOrRemoveDoctor = new AddOrRemoveDoctor();
            addOrRemoveDoctor.Show();
            Application.Exit();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Adminstrator adminstrator = new Adminstrator();
            adminstrator.Show();
            this.Hide();

        }

        private void AddClick(object sender, EventArgs e)
        {
            Reseptionest reseptionest = new Reseptionest();
            try
            {
                reseptionest.name =         FullName.Text;
                reseptionest.adress =       AddressBox.Text;
                reseptionest.age =          Convert.ToInt32(age.Text);
                reseptionest.Email =        EmailAdd.Text;
                reseptionest.gender =       gender.Text;
                reseptionest.hiringdate =   Hiring.Text;
                reseptionest.mirtal_status =Mirtal.Text;
                reseptionest.phonnumber =   Convert.ToInt32(Phone.Text);
                reseptionest.Usertypes.ID = Convert.ToInt32(UserID.Text);
            }
            catch
            {
                FullName.Clear();
                AddressBox.Clear();
                age.Clear();
                EmailAdd.Clear();

                Hiring.Clear();

                Phone.Clear();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void AddOrRemoveReceptionist_Load(object sender, EventArgs e)
        {
            var users = context.Usertypes.Select(u => u.UserName).ToArray();
            UserID.Items.AddRange(users);
        }
    }
}
