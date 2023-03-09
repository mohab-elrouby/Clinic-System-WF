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

    public partial class Adminstrator : Form
    {
        Model1 context = new Model1();
        public Adminstrator()
        {
            InitializeComponent();

        }

        private void Adminstrator_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User() { UserName = textBox1.Text, Password = textBox2.Text };
                if (comboBox1.Text == "Admin")
                {
                    user.type = "A";
                }
                else if (comboBox1.Text == "Doctor")
                {
                    user.type = "D";
                }
                else
                {
                    user.type = "R";
                }
                context.Usertypes.Add(user);

                context.SaveChanges();
                textBox1.Clear();
                textBox2.Clear();
            }
            catch
            {

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddOrRemoveDoctor addOrRemoveDoctor = new AddOrRemoveDoctor();
            addOrRemoveDoctor.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrRemoveReceptionist addOrRemoveReceptionist = new AddOrRemoveReceptionist();
            addOrRemoveReceptionist.Show();
            this.Hide();
        }
    }
}
