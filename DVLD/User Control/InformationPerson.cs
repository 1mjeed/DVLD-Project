using DVLBLL;
using DVLBLL.CountryBLL;
using DVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // مهم جداً للتعامل مع الملفات

namespace DVLD.User_Control
{
    public partial class InformationPerson : UserControl
    {
         private ManagePeopleBLL _Person;

        public InformationPerson()
        {
            InitializeComponent();
        }

        private void InformationPerson_Load(object sender, EventArgs e)
        {
            loaddate();
            loadCountry();

             linkLabel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void loaddate()
        {
            dateTimePicker.MinDate = DateTime.Now.AddYears(-100);
            dateTimePicker.Value = DateTime.Now.AddYears(-18);
            dateTimePicker.MaxDate = DateTime.Now.AddYears(-18);
        }

        private void loadCountry()
        {
            DataTable dtCountry = CountryBLL.GetAllCountry();
            comboBox1.DataSource = dtCountry;
            comboBox1.DisplayMember = "CountryName";
            comboBox1.ValueMember = "CountryID";
        }

         public void LoadPersonInfo(int personID)
        {
            _Person = ManagePeopleBLL.FindPeopleById(personID);

            if (_Person == null)
            {
                MessageBox.Show("The person was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBox5.Text = _Person.NationalNO;
            textBox1.Text = _Person.FirstName;
            textBox2.Text = _Person.SecondName;
            textBox3.Text = _Person.ThirdName;
            textBox4.Text = _Person.LastName;
            dateTimePicker.Value = _Person.DateOfBirth;
            comboBox1.SelectedValue = _Person.NationalityCountryID;
            textBox7.Text = _Person.Address;
            textBox6.Text = _Person.Email;
            textBox8.Text = _Person.Phone;

            if (_Person.Gendor == 0)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;

             if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                pictureBox1.Load(_Person.ImagePath);
                linkLabel2.Visible = true;  
            }
            else
            {
                pictureBox1.ImageLocation = null;
                linkLabel2.Visible = false; 
            }
        }

         private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Load(openFileDialog1.FileName);
                    linkLabel2.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحميل الصورة: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      
         private bool _HandlePersonImage()
         {           
            string currentDbImagePath = (_Person != null) ? _Person.ImagePath : "";

            if (pictureBox1.ImageLocation == currentDbImagePath)
            {
                return true;
            }

             if (!string.IsNullOrEmpty(currentDbImagePath) && File.Exists(currentDbImagePath))
            {
                try { File.Delete(currentDbImagePath); }
                catch (IOException ex) { Console.WriteLine(ex.Message); }
            }

             if (pictureBox1.ImageLocation != null)
            {
                string SourceImageFile = pictureBox1.ImageLocation.ToString();

                if (DVLD.Classes.clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                {
                    pictureBox1.ImageLocation = SourceImageFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء محاولة نسخ الصورة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

         private void button2_Click(object sender, EventArgs e)
        {
            Saveing();
        }

        private void Saveing()
        {
             if (!_HandlePersonImage())
            {
                return;
            }

             if (_Person == null)
            {
                _Person = new ManagePeopleBLL();
            }

            _Person.FirstName = textBox1.Text;
            _Person.SecondName = textBox2.Text;
            _Person.ThirdName = textBox3.Text;
            _Person.LastName = textBox4.Text;
            _Person.NationalNO = textBox5.Text;
            _Person.Email = textBox6.Text;
            _Person.Address = textBox7.Text;
            _Person.Phone = textBox8.Text;
            _Person.DateOfBirth = dateTimePicker.Value.Date;
            _Person.NationalityCountryID = Convert.ToInt32(comboBox1.SelectedValue);

            if (radioButton1.Checked)
                _Person.Gendor = Convert.ToByte(radioButton1.Tag);
            else if (radioButton2.Checked)
                _Person.Gendor = Convert.ToByte(radioButton2.Tag);

             _Person.ImagePath = pictureBox1.ImageLocation != null ? pictureBox1.ImageLocation : "";

            if (_Person.Save())
            {
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("We were unable to save the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            linkLabel2.Visible = false;
        }
    }
}