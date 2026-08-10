using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLBLL;

namespace DVLD.People
{
    public partial class ManagePeople : Form
    {
        public ManagePeople()
        {
            InitializeComponent();
        }
        private void ManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPepoleList();
        }
        private void _RefreshPepoleList()
        {
            DataTable dtPeople = ManagePeopleBLL.GetAllPepole();
            dataGridView1.DataSource = dtPeople;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedPersonId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            ShowDetails d = new ShowDetails(selectedPersonId);
            d.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdatePerson addPersonForm = new AddUpdatePerson();
            addPersonForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedPersonId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            AddUpdatePerson updatePersonForm = new AddUpdatePerson(selectedPersonId);
            updatePersonForm.ShowDialog();
            _RefreshPepoleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
          int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show($"Are you sure you want to delete this person , PersonID {id}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
               
                if (ManagePeopleBLL.DeletePerson(id))
                {
                    MessageBox.Show("Person deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPepoleList();
                }
               
            }
          
        }
    }
}
