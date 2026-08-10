using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class UserInformation : Form
    {
        private int _UserID; 

        public UserInformation(int userID)
        {
            InitializeComponent();
            this._UserID = userID;
        }

        private void Close_Click(object sender, EventArgs e)
        {

        }

        private void UserInformation_Load(object sender, EventArgs e)
        {
            userCartControl1.LoadUserInfo(_UserID); 
        }
    }
}
