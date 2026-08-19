using DVLBLL;
using DVLD.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicesnseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

        }

        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillLicenseClassesInComoboBox();


            if (_Mode == enMode.AddNew)
            {

                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
               // ctrlPersonCardWithFilter1.FilterFocus();
                tpApplicationInfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                butSave.Enabled = true;


            }

        }

        private void _LoadData()
        {

            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
             
            ctrlPersonCardWithFilter1.LoadPersonInf(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedByUser.Text = ManageUserBLL.FindUserByID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;

        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            _SelectedPersonID = PersonID;
            ctrlPersonCardWithFilter1.LoadPersonInf(PersonID);


        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Load_1(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }

        }

        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {



            if (_Mode == enMode.Update)
            {
                butSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
              // tabControl1.SelectedTab = tpApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }


            //incase of add new mode.
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                butSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                //tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  ctrlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Put the mouse over the red icon(s) to see the error.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;

            // حدد هوية الشخص بحزم واستخدمها في كل مكان!
            int currentPersonID = ctrlPersonCardWithFilter1.PersonID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(currentPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person already has an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }
            if (clsLicense.IsLicenseExistByPersonID(currentPersonID, LicenseClassID))
            {
                MessageBox.Show("Person already has a license with the same applied driving class. Choose a different driving class.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             try
            {
                _LocalDrivingLicenseApplication.ApplicantPersonID = currentPersonID;
                _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;

                _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;

                _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
                _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
                _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
                _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

                if (_LocalDrivingLicenseApplication.Save())
                {
                    lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

                    _Mode = enMode.Update;
                    lblTitle.Text = "Update Local Driving License Application";

                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A System Error Occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;

        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Activated(object sender, EventArgs e)
        {
          //  ctrlPersonCardWithFilter1.FilterFocus();
        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tpApplicationInfo_Click(object sender, EventArgs e)
        {

        }
    }
}