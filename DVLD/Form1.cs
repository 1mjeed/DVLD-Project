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
            AddUpdateUser p = new AddUpdateUser();
            p.ShowDialog(); 
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInformation p = new UserInformation(1);
            p.ShowDialog();
        }
    }
}
