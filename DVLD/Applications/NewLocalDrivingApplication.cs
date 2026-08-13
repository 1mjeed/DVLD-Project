using DVLBLL;
using DVLBLL.CountryBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class NewLocalDrivingApplication : Form
    {
        public NewLocalDrivingApplication()
        {
            InitializeComponent();
        }

        private void butSave_Click(object sender, EventArgs e)
        {

        }

        private void NewLocalDrivingApplication_Load(object sender, EventArgs e)
        {_LoadInfoLicenseClasses(); 

        }
        private void _LoadInfoLicenseClasses()
        {
            DataTable dtClasses = LicenseClassesBLL.AllClassesInfo();
            comboBox1.DataSource = dtClasses;
            comboBox1.DisplayMember = "ClassName";
            comboBox1.ValueMember = "LicenseClassID";
            comboBox1.DataSource = LicenseClassesBLL.AllClassesInfo();
        }
    }
}
