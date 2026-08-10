using DVLBLL;
using DVLD.User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class ChangePasswordForm : Form
    {
        private int _UserID;
        private ManageUserBLL _User; 

        public ChangePasswordForm(int id)
        {
            InitializeComponent();
            _UserID = id;
        }
        private void _ResetDefualtValues()
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox1.Focus();
        }
        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            _User = ManageUserBLL.FindUserByID(_UserID);
            if (_User == null)
            {
                MessageBox.Show($"Could Not Find User  with id =  {_UserID}");
                this.Close();
                return; 
            }
            userCartControl1.LoadUserInfo(_UserID); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide");
                return;
            }
            _User.Password = maskedTextBox2.Text;
            if (_User.Save())
            {
                MessageBox.Show("Password Changed Successfully!!");
            }
            else
            {
                MessageBox.Show("Password Changed Not  Successfully!!");

            }

        }
         
        

        private void maskedTextBox1_MaskInputRejected(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(maskedTextBox1, "???");
                return;
            }
            else
            {
                e.Cancel = false;

                errorProvider1.SetError(maskedTextBox1, null);
            }
            ;
            if (_User.Password != maskedTextBox1.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(maskedTextBox1, "Current Password is Wrong");
                return;
            }
            else
            {
                e.Cancel = false;


                errorProvider1.SetError(maskedTextBox1, null);

            }
        }

        private void maskedTextBox2_MaskInputRejected(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox2.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(maskedTextBox2, "???");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(maskedTextBox2, null);
            }
            ;
        }

        private void maskedTextBox3_MaskInputRejected(object sender, CancelEventArgs e)
        {
            if (maskedTextBox3.Text.Trim() != maskedTextBox2.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(maskedTextBox3, "Password Confirm isn't equals New Password");
                
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(maskedTextBox3, null);
            }
        }
    }
}
