using DVLBLL;
using DVLD.Applications;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD 
{
    public partial class ManageApplicationTypes : Form
    {
        private DataTable _dtAllApplicationTypes;
        public ManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dataGridView1.DataSource = _dtAllApplicationTypes;
             if (_dtAllApplicationTypes != null && _dtAllApplicationTypes.Rows.Count > 0)
            {
                 dataGridView1.Columns["ApplicationTypeID"].HeaderText = "ID";
                dataGridView1.Columns["ApplicationTypeID"].Width = 110;

                dataGridView1.Columns["ApplicationTypeTitle"].HeaderText = "Title";
                dataGridView1.Columns["ApplicationTypeTitle"].Width = 400;

                dataGridView1.Columns["ApplicationFees"].HeaderText = "Fees";
                dataGridView1.Columns["ApplicationFees"].Width = 100;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            ManageApplicationTypes_Load(null, null);
        } 
    }
}
