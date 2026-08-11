using DVLBLL;
using System;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class LoginForm : Form
    {
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
            string username = textBox1.Text; 
            string password = maskedTextBox1.Text;
            if (ManageUserBLL.Login(username , password))
            {
                isFound = true;
            }

            return isFound; 
        }
        private void login()
        {
            if (!checkedUserExist())
            {
                MessageBox.Show("PassWord Or UserName not Valid");
                return;

            }
            else
            {
                Form1 ma = new Form1();
                ma.ShowDialog();
                this.Close();
            }
        }
    }
}
