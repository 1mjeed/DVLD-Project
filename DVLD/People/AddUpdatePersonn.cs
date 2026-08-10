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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD.People
{
    public partial class AddUpdatePerson : Form
    {
        private enum _Mode {addMode=0,UpdateMode=1}
        private _Mode _mode ;
        private int _id ;
        ManagePeopleBLL person;

        public AddUpdatePerson()
        {
            InitializeComponent();
            _mode = _Mode.addMode;
        }
        public AddUpdatePerson(int IdPerson)
        {
            InitializeComponent();
            _id = IdPerson;
            _mode = _Mode.UpdateMode;
        }

        private void AddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
        }

        private void informationPerson1_Load(object sender, EventArgs e)
        {

        }
        private void _ResetDefualtValues()
        {
            if (_mode==_Mode.addMode)
            {
                label1.Text = "Add New Person";
                person = new ManagePeopleBLL();
                
            }
            else
            {
                label1.Text = "Update Person";
                if (_mode == _Mode.UpdateMode)
                {
                    informationPerson1.LoadPersonInfo(_id);
                }

            }
        }
 
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
