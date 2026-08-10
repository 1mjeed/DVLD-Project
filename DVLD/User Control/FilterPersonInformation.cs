using DVLBLL;
using DVLD.People;
using DVLD.User_Control;
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
    public partial class FilterPersonInformation : UserControl
    {
        public FilterPersonInformation()
        {
            InitializeComponent();
        }
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if(handler != null)
            {
                handler(PersonID);
            }
        }
        private bool _showAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _showAddPerson; }
            set
            { _showAddPerson = value;
                AddPerson.Visible= _showAddPerson; 
            }
        }
        private bool _FilterEnabled = true ; 
        public bool FilterEnabled
        {
            get
            { return _FilterEnabled;
            }
            set
            { _FilterEnabled = value;
                groupBox1.Visible = _FilterEnabled;
            }
        }
        private int _PersonID = -1 ;
        public int PersonID
        {
            get { return cartPersonInformation1.PersonID; }
        }

        public ManagePeopleBLL SelectedPersonInfo
        {
            get { return cartPersonInformation1.SelectedPersonInfo; }
        }
        public void LoadPersonInf(int PersonID)
        {
            comboBox1.SelectedIndex = 1;
            textBox1.Text = PersonID.ToString();
            FindNow(); 
        }
        private void FindNow()
        {
            switch (comboBox1.Text)
            {
                case "Person ID":
                    cartPersonInformation1.LoadPersonInfo(int.Parse(textBox1.Text));
                    break;
                case "National NO":
                    cartPersonInformation1.LoadPersonInfo(textBox1.Text);
                    break;
                default: break;
            }
            if (OnPersonSelected != null && FilterEnabled)
            {
                OnPersonSelected(cartPersonInformation1.PersonID);
            }
        }
        private void FilterPersonInformation_Load(object sender, EventArgs e)
        {

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = ""; 
            textBox1.Focus();
        }

        private void AddPerson_Click(object sender, EventArgs e)
        {
            //AddUpdatePerson fadd = new AddUpdatePerson();
            //fadd.DataBake
            // هون بالمستقبل بدي منك تعمل ديلقيت 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 )
            {
                button1.PerformClick();
            }
            if(comboBox1.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            FindNow();        
        }
    }
}
