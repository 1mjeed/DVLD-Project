using DVLBLL;
using DVLD.People;
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
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateUser addPersonForm = new AddUpdateUser();
            addPersonForm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedPersonId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            UserInformation user = new UserInformation(selectedPersonId);
            user.ShowDialog(); 
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedPersonId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            AddUpdateUser updateUserForm = new AddUpdateUser(selectedPersonId);
            updateUserForm.ShowDialog();
            _RefreshUserList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show($"Are you sure you want to delete this person , PersonID {id}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                if (ManageUserBLL.DeleteUser(id))
                {
                    MessageBox.Show("Person deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUserList();
                }

            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ChangePasswordForm ch = new ChangePasswordForm(id); 
            ch.ShowDialog();
            _RefreshUserList(); 
        }
        private void _RefreshUserList()
        {
            DataTable dtPeople = ManageUserBLL.GetAllUsers();
            dataGridView1.DataSource = dtPeople;
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUserList(); 
        }
    }
}
