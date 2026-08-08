using DVLDAL;
using System;
using System.Data;

namespace DVLBLL
{
    public class User
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

         public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

         public User()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;  
            Mode = enMode.AddNew;
        }

         private User(int userID, int personID, string userName, string password, bool isActive)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;

            Mode = enMode.Update;
        }
 

        public static DataTable GetAllUsers()
        {
             return UserDAL.GetAllUsers();
        }

        public static User FindUserByID(int userID)
        {
             int personID = -1;
            string userName = "";
            string password = "";
            bool isActive = false;
             if (UserDAL.GetUserInfoByUserID(userID, ref personID, ref userName, ref password, ref isActive))
            {
                 return new User(userID, personID, userName, password, isActive);
            }
            else
            {
                 return null;
            }
        }

        public static bool IsExist(int userID)
        {
            return UserDAL.IsUserExist(userID);
        }

        public static bool DeleteUser(int userID)
        {
            return UserDAL.DeleteUser(userID);
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