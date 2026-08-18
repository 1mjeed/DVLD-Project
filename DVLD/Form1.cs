using DVLD.Applications;
using DVLD.People;
using DVLD.User;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 namespace DVLD
{   
    public partial class Form1 : Form
    {
        private int idUser = DVLD.Classes.clsGlobal.CurrentUser.UserID; 
         public Form1()
        {
            InitializeComponent();
        }

        

        private void pepoleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManagePeople managepeople = new ManagePeople();
            managepeople.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsers p = new ManageUsers();
            p.ShowDialog(); 
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInformation p = new UserInformation(idUser);
            p.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm f = new ChangePasswordForm(idUser);
            f.ShowDialog();
        }

        private void sinOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DVLD.Classes.clsGlobal.CurrentUser = null; 
                this.Hide ();
            LoginForm f = new LoginForm();
            f.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypes m = new ManageApplicationTypes();
            m.ShowDialog();
        }

        private void pepoleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestTypes ty = new TestTypes();
            ty.ShowDialog();
        }

        private void ggToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocalDrivingApplication lic = new NewLocalDrivingApplication();
            lic.ShowDialog();
        }

        private void localDrivingApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
