using DVLBLL;
using System;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class LoginForm : Form
    {
        private int _id = -1 ;       
        public LoginForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            login(); 
        }
        private bool checkedUserExist()
        {
            bool isFound = false;   
            _id = ManageUserBLL.Login(textBox1.Text, maskedTextBox1.Text);
            if ( _id!=-1) { isFound = true; }
            return isFound; 
        }
        private void login()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                MessageBox.Show("Please enter both Username and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!checkedUserExist())
            {
                MessageBox.Show("Invalid Username or Password, or the account is inactive.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                 
            }
            else
            {
                Classes.clsGlobal.CurrentUser = ManageUserBLL.FindUserByID(_id);
                this.Hide();
                Form1 ma = new Form1();
                ma.ShowDialog();
                this.Close();
            }
        }
    }
}
