using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class AddUpdatePerson : Form
    {
        private enum _Mode { AddMode = 0, UpdateMode = 1 }
        private _Mode _mode = _Mode.AddMode;
        private int _ID;
        public AddUpdatePerson()
        {
            InitializeComponent();
            _mode = _Mode.AddMode;
        }
        public AddUpdatePerson(int id )
        {
            InitializeComponent();
            _mode = _Mode.UpdateMode;
            _ID = id;
        }
       

        private void AddUpdatePerson_Load(object sender, EventArgs e)
        {
            SelectMode(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void SelectMode()
        {
            switch (_mode) 
            {
            case _Mode.AddMode:
              label1.Text = "Add A Person";
               break ;
            case _Mode.UpdateMode:
               label1.Text = "Update A Person";
                    informationPerson1.LoadPersonInfo(_ID);

                    break;             
            }

        }

        private void informationPerson1_Load(object sender, EventArgs e)
        {

        }
    }
}
