using DVLBLL;
using DVLBLL.CountryBLL;
using DVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD.User_Control
{
    public partial class CartPersonInformation : UserControl
    {
         //private int _Id;
        private ManagePeopleBLL _Person;
        private CountryBLL _Country;
        private int _PersonId = -1; 
        public int PersonID
        {
            get { return _PersonId; }
        }
            public ManagePeopleBLL SelectedPersonInfo
              {
                 get { return _Person; }
              }
        public CartPersonInformation()
        {
            InitializeComponent();
        }

        private void CartPersonInformation_Load(object sender, EventArgs e)
        {
            
        }
        private void _FillPersonInfo()
        {
             _PersonId = _Person.PersonID;
             textBox1.Text = _Person.PersonID.ToString();
            textBox9.Text = CountryBLL.GetNameCountry(_Person.NationalityCountryID).ToString();
            textBox8.Text = _Person.Phone;
            textBox7.Text = _Person.DateOfBirth.ToShortDateString();
            textBox6.Text = _Person.Address;
            textBox5.Text = _Person.Email;
            textBox4.Text = _Person.Gendor == 0 ? "Male" : "Female";
            textBox3.Text = _Person.NationalNO;
            textBox2.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;

            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                pictureBox1.Load(_Person.ImagePath);
            }
            else
            {
                 pictureBox1.ImageLocation = null;
            }
        }

        public void LoadPersonInfo(int personID)
        {
 
            _Person = ManagePeopleBLL.FindPeopleById(personID);

            if (_Person == null)
            {
                MessageBox.Show("The person was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           _FillPersonInfo();
        }
        public void LoadPersonInfo(string nationalNo)
        {
             _Person = ManagePeopleBLL.FindPeopleByNationalNo(nationalNo);
             if (_Person == null)
            {
                MessageBox.Show("The person with National Number [" + nationalNo + "] was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
        }
    }
}
