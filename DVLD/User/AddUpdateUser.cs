using DVLBLL;
using System;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class AddUpdateUser : Form
    {
        public enum enMode { Add = 0, Update = 1 }
        private enMode _mode;
        private int _userID = -1;

        private ManageUserBLL _User;

        public AddUpdateUser()
        {
            InitializeComponent();
            _mode = enMode.Add;
        }

        public AddUpdateUser(int UserID)
        {
            InitializeComponent();
            _mode = enMode.Update;
            _userID = UserID;
        }

         private void AddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void _ResetDefaultValues()
        {
            if (_mode == enMode.Add)
            {
                label1.Text = "Add New User";
                this.Text = "Add New User";
                 btnSave.Enabled = false;
                tabPage2.Enabled = false;
            }
            else
            {
                label1.Text = "Update User";
                this.Text = "Update User"; 
                btnSave.Enabled = true;
                tabPage2.Enabled = true;
            }
        }

        private void _LoadData()
        {
            _User = ManageUserBLL.FindUserByID(_userID);

             filterPersonInformation1.FilterEnabled = false;

             filterPersonInformation1.LoadPersonInf(_User.PersonID);

            if (_User == null)
            {
                MessageBox.Show($"No User With ID = {_userID}", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
             if (_mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tabPage2.Enabled = true;
                tabControl1.SelectedTab = tabPage2;
                return; 
            }

             if (filterPersonInformation1.PersonID != -1)
            {
                 if (ManageUserBLL.IsUserExist(filterPersonInformation1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a user account!", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }
                else
                {
                    btnSave.Enabled = true;
                    tabPage2.Enabled = true;
                    tabControl1.SelectedTab = tabPage2;
                }
            }
            else
            {
                MessageBox.Show("Please Select a person first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
         private void filterPersonInformation1_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Saving(); 
        }
        private void Saving()
        {
            _User.PersonID = filterPersonInformation1.PersonID;
            _User.UserName =  textBox1.Text; 
            _User.Password = textBox2.Text; 
            _User.IsActive = checkBox1.Checked ? true : false; 
            if (_User.Save())
            {
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("We were unable to save the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}