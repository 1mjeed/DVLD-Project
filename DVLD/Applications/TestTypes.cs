using System;
using System.Windows.Forms;
using DVLBLL; 

namespace DVLD.Applications
{
    public partial class TestTypes : Form
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

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
            dataGridView1.DataSource = clsTestType.GetAllTestTypes();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _TestTypeID = (clsTestType.enTestType)Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            frmEditTestType test = new frmEditTestType(_TestTypeID);
            test.Show();
            GetAllInfo();
        }

    }
}
 