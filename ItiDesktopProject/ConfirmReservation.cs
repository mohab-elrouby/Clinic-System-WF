using clinckDB.databaseclincik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItiDesktopProject
{

    public partial class ConfirmReservation : Form
    {
        Model1 context = new Model1();
        public List<Patient> patients { get; set; }
        public Doctor docID { get; set; }
        public Clinic clinicID { get; set; }
        Dictionary<string, string> daysDict = new Dictionary<string, string>(){
            {"day0", "Sun"},
            {"day1", "Mon"},
            {"day2", "Tue"},
            {"day3", "Wed"},
            {"day4", "Thu"},
            {"day5", "Fri"},
            {"day6", "Sat"}
        };
        Dictionary<string, int> daysNumsDict = new Dictionary<string, int>(){
            {"Sun", 0},
            {"Mon", 1},
            {"Tue", 2},
            {"Wed", 3},
            {"Thu", 4},
            {"Fri", 5},
            {"Sat", 6}
        };
        Dictionary<string, string> hoursDict = new Dictionary<string, string>(){
            {"1", "09:00AM"},
            {"2", "09:30AM"},
            {"3", "10:00AM"},
            {"4", "10:30AM"},
            {"5", "11:00AM"},
            {"6", "11:30AM"},
            {"7", "12:00PM"},
            {"8", "12:30PM"},
            {"9", "01:00PM"},
            {"10", "01:30PM"},
            {"11", "02:00PM"},
            {"12", "02:30PM"},
            {"13", "03:00PM"},
            {"14", "03:30PM"},
            {"15", "04:00PM"},
            {"16", "04:30PM"},
            {"17", "05:00PM"},
            {"18", "05:30PM"},
            {"19", "06:00PM"},
            {"20", "06:30PM"},
            {"21", "07:00PM"},
            {"22", "07:30PM"},
            {"23", "08:00PM"},
            {"24", "08:30PM"}
        };
        public ConfirmReservation()
        {
            InitializeComponent();
        }


        private void ConfirmReservation_Load(object sender, EventArgs e)
        {
            // listBox1.Hide();
            var context = new Model1();
            patients = (from p in context.Patients

                        select p).ToList();
            // listBox1.Hide();

            PatientEmailTxt.ReadOnly = false;
            richTextBox2.ReadOnly = false;

            label3.Text = " ";
            label6.Text = " ";
            label12.Text = " ";
            label13.Text = " ";

            //get doctor name 
            var doctorNameQuery = (from d in context.Doctors
                                   where d.doctorID ==  docID.doctorID
                                   select d.name).FirstOrDefault();

            DoctorTxt.Text = doctorNameQuery;
            //get clinic ID
            var doctorClinicIdQuery = (from dd in context.Doctors
                                       where dd.doctorID == docID.doctorID
                                       select dd.ClinicId).FirstOrDefault();

            //get clinic name      
            var GetClinicName = (from c in context.Clincs
                                 where c.clinicID == clinicID.clinicID
                                 select c.clinic_name).FirstOrDefault();

            ClinicTxt.Text = GetClinicName;
            #region Design
            DoctorTxt.ForeColor = Color.White;
            ClinicTxt.ForeColor = Color.White;
            PatientPhoneTxt.ForeColor = Color.White;
            PatientEmailTxt.ForeColor = Color.White;
            richTextBox2.ForeColor = Color.White;
            GenderComboBox.ForeColor = Color.White;
            maritalComboBox.ForeColor = Color.White;
            DayComboBox.ForeColor = Color.White;
            TimeComboBox.ForeColor = Color.White;
            textBox1.ForeColor = Color.White;
            comboBox2.ForeColor = Color.White;
            maritalComboBox.BackColor = Color.FromArgb(61, 168, 125);
            maritalComboBox.Font = new Font("Microsoft Sans Serif", 14);
            GenderComboBox.Font = new Font("Microsoft Sans Serif", 14);
            textBox1.Font = new Font("Microsoft Sans Serif", 16);
            GenderComboBox.BackColor = Color.FromArgb(61, 168, 125);
            textBox1.BackColor = Color.FromArgb(61, 168, 125);
            comboBox2.BackColor = Color.FromArgb(61, 168, 125);
            TimeComboBox.Font = new Font("Microsoft Sans Serif", 14);
            TimeComboBox.BackColor = Color.FromArgb(61, 168, 125);
            DayComboBox.Font = new Font("Microsoft Sans Serif", 14);
            DayComboBox.BackColor = Color.FromArgb(61, 168, 125);
            maritalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion
            #region add items to marital list
            maritalComboBox.Items.Add("Single");
            maritalComboBox.Items.Add("Married");
            maritalComboBox.SelectedIndex = 0;
            #endregion

            #region add items to gender list
            GenderComboBox.Items.Add("Male");
            GenderComboBox.Items.Add("Female");
            GenderComboBox.SelectedIndex = 0;
            #endregion


            var daysQuery = context.Doctor_Slots.Include("Slots").Where(d => d.DoctorID == docID.doctorID).Select(d => d.Slots.day).Distinct().ToList();
            TimeComboBox.DropDownHeight = 150;
            DayComboBox.DropDownHeight = 150;
            foreach (var item in daysQuery)
            {
                DayComboBox.Items.Add(daysDict[item]);
            }
            if (DayComboBox.Items.Count > 0)
            {

                DayComboBox.SelectedIndex = 0;
            }
            if (TimeComboBox.Items.Count > 0)
            {

                TimeComboBox.SelectedIndex = 0;
            }
            comboBox2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region Name Validation

            string patientName = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(patientName))
            {
                label13.Text = "Please Enter Patient Name.";
                label13.ForeColor = Color.Red;
                return;
            }


            Regex regex2 = new Regex(@"^[a-zA-Z]+ [a-zA-Z]+ [a-zA-Z]+$");

            if (!regex2.IsMatch(patientName))
            {
                label13.Text = "Please enter Full Name, Char only.";
                label13.ForeColor = Color.Red;

                return;
            }
            label13.Text =" ";

            #endregion
            #region Phone Validation
            // Phone Validation
            string pattern = @"^(01)[0125][0-9]{8}$";

            string phoneNumber = PatientPhoneTxt.Text.Trim();
            if (string.IsNullOrEmpty(phoneNumber))
            {
                label12.Text = "Please enter Egypt phone number.";
                label12.ForeColor = Color.Red;
                return;

            }
            if (!Regex.IsMatch(phoneNumber, pattern))
            {
                label12.Text = "Please enter a valid Egypt phone number.";
                label12.ForeColor = Color.Red;
                return;

            }
            label12.Text = " ";
            #endregion
            #region Email Validation
            // Email Validation
            string email = PatientEmailTxt.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                label3.Text = "Please enter an email address.";
                label3.ForeColor = Color.Red;

                return;
            }

            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            if (!regex.IsMatch(email))
            {
                label3.Text = "Please enter a valid email address.";
                label3.ForeColor = Color.Red;

                return;
            }
            label3.Text = " ";
            #endregion

            #region Age Validation
            // Age Validation
            string ageString = richTextBox2.Text.Trim();
            if (string.IsNullOrEmpty(ageString))
            {
                label6.Text = "Please enter Age.";
                label6.ForeColor = Color.Red;

                return;
            }
            int age;

            if (!Int32.TryParse(richTextBox2.Text, out age))
            {
                label6.Text = "Please enter a valid Age.";
                label6.ForeColor = Color.Red;
                return;

            }
            if (age < 0)
            {
                label6.Text = "Age must over 0.";
                return;
            }
            label6.Text = " ";
            #endregion

            Patient patient = patients.Where(p => p.name == textBox1.Text).Select(p => p).FirstOrDefault();
            // make reservation
            if (patient == null)
            {
                patient= new Patient
                {
                    name = textBox1.Text,
                    phonnumber = PatientPhoneTxt.Text,
                    Email = PatientEmailTxt.Text,
                    age = Int32.Parse(richTextBox2.Text),
                    mirtal_status = maritalComboBox.SelectedItem.ToString(),
                    gender = GenderComboBox.SelectedItem.ToString()
                };
                context.Patients.Add(patient);
            }
            int offset = 0;
            var currDay = (int) DateTime.Today.DayOfWeek;
            offset = (currDay > daysNumsDict[DayComboBox.SelectedItem.ToString()]) ? 0 : 7;
            string visitDate= DateTime.Today.AddDays((int)(DateTime.Today.DayOfWeek - daysNumsDict[DayComboBox.SelectedItem.ToString()])).ToString().Split(' ')[0];
            Clinic clnc = context.Clincs.Where(c =>c.clinicID == docID.ClinicId).FirstOrDefault();
            context.Visites.Add(
                new Visit
                {
                    Visit_Status = visit_statuse.Confirmed,
                    PatientID= patient.ID,
                    visit_date = visitDate,
                    visit_time = TimeComboBox.SelectedItem.ToString(),
                    DoctorId = docID.doctorID,
                    Clinc = clnc
                });


            // change selected time Stauts to Reserved.
            string selectedDay = DayComboBox.SelectedItem.ToString();
            selectedDay = daysDict.FirstOrDefault(x => x.Value == selectedDay).Key;
            var selectedTime = hoursDict.FirstOrDefault(x => x.Value ==TimeComboBox.SelectedItem.ToString()).Key;
            var selectedReservedTime = (from d in context.Doctor_Slots
                                        where d.Slots.slots_times == selectedTime && d.DoctorID == docID.doctorID && d.Slots.day == selectedDay
                                        select d).FirstOrDefault();
            selectedReservedTime.isReserved = true;
            context.SaveChanges();

            //MessageBox.Show(" Reserved Done Successfully ", " Reservation", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Close();
            //Clear();
            //DayComboBox.Items.Clear();
            //TimeComboBox.Items.Clear();    
            ////get doctor days after reservation.
            //docID = (from d in context.Doctors
            //         where d.name == "bahaa" ///???////////////////////////////////////???
            //         select d.doctorID).FirstOrDefault();

            //var daysQuery = from d in context.Doctor_Slots
            //                where d.DoctorID == docID && d.isReserved == false
            //                select d.Slots.day;
            //foreach (var item in daysQuery)
            //{
            //    if (!DayComboBox.Items.Contains(item))
            //    {
            //        DayComboBox.Items.Add(item);
            //    }
            //}
            //DayComboBox.SelectedIndex = 0;

            //comboBox2.DroppedDown = false;
        }

        //clear boxes data.
        private void Clear()
        {
            textBox1.Text = " ";
            PatientPhoneTxt.Text = " ";
            richTextBox2.Text = " ";
            PatientEmailTxt.Text = " ";
        }


        private void DayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeComboBox.Items.Clear();
            string selectedDay = DayComboBox.SelectedItem.ToString();
            selectedDay = daysDict.FirstOrDefault(x => x.Value == selectedDay).Key;
            // get doctor times
            var timeQuery = from d in context.Doctor_Slots
                            where d.DoctorID == docID.doctorID && d.Slots.day == selectedDay && d.isReserved == false //&& day == ??
                            select new { slotsTime = d.Slots.slots_times };

            foreach (var item in timeQuery)
            {
                TimeComboBox.Items.Add(hoursDict[item.slotsTime]);
            }
            TimeComboBox.SelectedIndex = 0;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                using (var db = new Model1())
                {
                    var query = from item in db.Patients
                                where item.name.Contains(textBox1.Text)
                                select item.name;
                    var suggestions = query.ToList();
                    if (suggestions.Any())
                    {
                        comboBox2.DataSource = suggestions;
                        comboBox2.Visible = true;
                        comboBox2.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        // Clear();
                        comboBox2.Visible = false;
                        comboBox2.DroppedDown = false;
                    }
                }
            }
            else
            {
                comboBox2.Visible = false;
                comboBox2.DroppedDown = false;
            }

        }


        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox1.Text = comboBox2.SelectedItem.ToString();
            var query8 = (from d in context.Patients
                          where d.name == textBox1.Text.ToString()
                          select d).FirstOrDefault();

            PatientPhoneTxt.Text = query8.phonnumber;
            GenderComboBox.Text = query8.gender;
            maritalComboBox.Text = query8.mirtal_status;
            PatientEmailTxt.Text = query8.Email;
            PatientPhoneTxt.Text = query8.phonnumber;
            richTextBox2.Text = query8.age.ToString();
            comboBox2.Visible = false;

            if (textBox1.Text != "")
            {
                if (patients.Where(p => p.name == textBox1.Text).Select(p => p.name).FirstOrDefault() != null)
                {
                    PatientEmailTxt.ReadOnly = true;
                    richTextBox2.ReadOnly = true;
                }
                else
                {
                    PatientEmailTxt.ReadOnly = false;
                    richTextBox2.ReadOnly = false;
                }
            }
            else
            {
                PatientEmailTxt.ReadOnly = false;
                richTextBox2.ReadOnly = false;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                PatientEmailTxt.ReadOnly = false;
                richTextBox2.ReadOnly = false;
            }

        }
    }
}
