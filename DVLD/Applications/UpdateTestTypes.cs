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
namespace DVLD 
{
    public partial class UpdateTestTypes : Form
    {
        private int _ID=-1;
        TestTypesBLL Type ; 
        public UpdateTestTypes(int id )
        {
            InitializeComponent();
            _ID= id;
        }

        private void UpdateTestTypes_Load(object sender, EventArgs e)
        {
            _Load(); 
        }
        private void _Load()
        {
            try 
            {
                Type = TestTypesBLL.GetTypeByID(_ID);
                if( Type == null)
                {
                    MessageBox.Show("Sorry, data for this test was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                label4.Text = Type.ID.ToString();
                textBox1.Text = Type.title;
                textBox3.Text = Type.description;
                textBox2.Text = Type.Fees.ToString();

            }
            catch( Exception ex ) 
            {
                MessageBox.Show("حدث خطأ أثناء الاتصال بقاعدة البيانات: " + ex.Message, "خطأ نظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
           
          
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            save(); 
        }
        private void save()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please fill in the title and description before saving.", "alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox2.Text.Trim(), out decimal validFees))
            {
                MessageBox.Show("Please enter a valid monetary value in the fees field.", "alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Type.title = textBox1.Text.Trim();
            Type.description = textBox3.Text.Trim();
            Type.Fees = validFees;

            try
            {
                if (Type.Save())
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
