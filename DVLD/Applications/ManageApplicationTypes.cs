using DVLBLL;
using DVLD.Applications;
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
    public partial class ManageApplicationTypes : Form
    {
        public ManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList(); 
        }
        private void _RefreshApplicationTypesList()
        {
            try
            {  
                _RefreshUserList();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(" Database connection issue – details :  " + ex.Message, "System error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedPersonId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            UpdateApplicationTypes updateUserForm = new UpdateApplicationTypes(selectedPersonId);
            updateUserForm.ShowDialog();
            _RefreshUserList();
        }
        private void _RefreshUserList()
        {
            DataTable dtApplicationType = ApplicationTypeBLL.GetAllApplicationTypes();
            dataGridView1.DataSource = dtApplicationType;
        }
        
    }
}
