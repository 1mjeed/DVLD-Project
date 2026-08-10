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

namespace DVLD.User
{
    public partial class UserCartControl : UserControl
    {
        private ManageUserBLL _User;
        private int _UserID = -1;
        public int UserID
        {
            get { return _UserID; }
        }

        public UserCartControl()
        {
            InitializeComponent();
        }
        public void LoadUserInfo(int UserID )
        {
            _User = ManageUserBLL.FindUserByID(UserID);
            if (_User == null) 
            {             
                MessageBox.Show($"No User with UserID =  {UserID.ToString()}");
                return; 
            }
            _FillUserInfo();
        }

        private void _FillUserInfo()
        {
            cartPersonInformation1.LoadPersonInfo(_User.PersonID);
            label3.Text = _User.UserID.ToString();
            label4.Text = _User.UserName.ToString();
            label5.Text = _User.IsActive == true ?  "Yes": "No";
        }
        

       
    }
}
