using DVLBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class UpdateApplicationTypes : Form
    {
        private int _ID;
        private ApplicationTypeBLL _applicationTypeBLL; 
        public UpdateApplicationTypes(int id)
        {
            InitializeComponent();
            _ID = id;
        }

        private void UpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            _r(); 
        }
        private void _r()
        {
            _applicationTypeBLL = ApplicationTypeBLL.Find(_ID);
            label4.Text = _applicationTypeBLL.ApplicationTypeID.ToString();
            textBox1.Text = _applicationTypeBLL.ApplicationTypeTitle;
            textBox2.Text = _applicationTypeBLL.ApplicationFees.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

             if (!decimal.TryParse(textBox2.Text.Trim(), out decimal validFees))
            {
                MessageBox.Show("Please enter a valid monetary value in the fees field.", "alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
             _applicationTypeBLL.ApplicationTypeTitle = textBox1.Text.Trim();
             _applicationTypeBLL.ApplicationFees = validFees;

             try
            {
                if (_applicationTypeBLL.Save())
                {
                    MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("We were unable to save the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Database connection issue – details :  " + ex.Message, "System error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}
