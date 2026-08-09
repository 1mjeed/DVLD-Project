using DVLDAL;
using System;
using System.Data;

namespace DVLBLL
{
    public class ManageUserBLL
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public ManagePeopleBLL person; 
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

         public ManageUserBLL()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;  
            Mode = enMode.AddNew;
        }

         private ManageUserBLL(int userID, int personID, string userName, string password, bool isActive)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.person = ManagePeopleBLL.FindPeopleById(personID);
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;

            Mode = enMode.Update;
        }
 

        public static DataTable GetAllUsers()
        {
             return UserDAL.GetAllUsers();
        }

        public static ManageUserBLL FindUserByID(int userID)
        {
             int personID = -1;
            string userName = "";
            string password = "";
            bool isActive = false;
             if (UserDAL.GetUserInfoByUserID(userID, ref personID, ref userName, ref password, ref isActive))
            {
                 return new ManageUserBLL(userID, personID, userName, password, isActive);
            }
            else
            {
                 return null;
            }
        }

        public static bool IsUserExist(int userID)
        {
            return UserDAL.IsUserExist(userID);
        }
        public static bool IsUserExist(string UserName)
        {
            return UserDAL.IsUserExist(UserName);
        }
        public static bool IsUserExistforPassword(string Password)
        {
            return UserDAL.IsUserExist(Password);
        }

        public static bool DeleteUser(int userID)
        {
            return UserDAL.DeleteUser(userID);
        }
        public static bool ChangePassword(int id, string password)
        {
            return UserDAL.ChangePassword(id, password);
        }

        private bool _AddNewUser()
        {
             this.UserID = UserDAL.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return UserDAL.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }
    }
}