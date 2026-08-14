using DVLBLL;
using DVLBLL.License;
using DVLD.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class NewLocalDrivingApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _LocalDrivingLicenseAppID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApp;
        public NewLocalDrivingApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public NewLocalDrivingApplication(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
        }
        private void NewLocalDrivingApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void _FillLicenseClassesInComboBox()
        {
            DataTable dtClasses = LicenseClassesBLL.AllClassesInfo();
            cbLicenseClass.DataSource = dtClasses;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";

           
        }
        private void _loadLa()
        {
            laDate.Text = DateTime.Now.ToShortDateString();
            laCreatedBy.Text = ManageUserBLL.FindUserByID(clsGlobal.CurrentUser.UserID).UserName.ToString();
            laFees.Text = ApplicationTypeBLL.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
        }

        private void _LoadData()
        {
            _loadLa();
             _FillLicenseClassesInComboBox();
             if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApp = new clsLocalDrivingLicenseApplication();
                return;
            }
             lblTitle.Text = "Update Local Driving License Application";
            
            _LocalDrivingLicenseApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseAppID);
             if (_LocalDrivingLicenseApp == null)
            {
                MessageBox.Show("عذراً، هذا الطلب غير موجود في النظام!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }  
             cbLicenseClass.SelectedValue = _LocalDrivingLicenseApp.LicenseClassID;
        }
         

        private void btnNext_Click(object sender, EventArgs e)
        { 

            tabControl1.SelectedIndex = 1;
 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // الكود الذي سيكتب هنا لاحقاً سيعتمد بالكامل على الكائن _LocalDrivingLicenseApp
            // لأنه يعرف مسبقاً هل هو AddNew أم Update بفضل دالة الـ Save المدمجة بداخله!
        }
    }
}