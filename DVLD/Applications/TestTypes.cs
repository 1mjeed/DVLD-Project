using System;
using System.Windows.Forms;
using DVLBLL; 

namespace DVLD.Applications
{
    public partial class TestTypes : Form
    {
        public TestTypes()
        {
            InitializeComponent();
        }

        private void TestTypes_Load(object sender, EventArgs e)
        {
            GetAllInfo();
        }
        private void GetAllInfo()
        {
            dataGridView1.DataSource = TestTypesBLL.GetAllInfo();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedPersonId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            UpdateTestTypes test = new UpdateTestTypes(selectedPersonId);
            test.Show();
            GetAllInfo();
        }

    }
}
 