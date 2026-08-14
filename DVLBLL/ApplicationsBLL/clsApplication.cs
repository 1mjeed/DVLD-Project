using DVLDAL;  
using System;
using System.Data;

namespace DVLBLL
{
    public class clsApplication
    {
         public enum enMode { AddNew = 0, Update = 1 };
        public enum enApplicationType {NewDrivingLicense =1 , RenewDrivingLicense = 2 ,ReplaceLostDrivingLicense = 3  , ReplaceDamagedDrivingLicense = 4 , ReleaseDetainedDrivingLicsense=5 , NewInternational = 6 , RetakeTest = 7}

        public enMode Mode = enMode.AddNew;
        public enum enApplicationStatus {New = 1 , Cancelled = 2 , Completed = 3  }


        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }

        public ManagePeopleBLL PersonInfo; 
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText 
        {
            get 
            {
                switch (ApplicationStatus) 
                {
                case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown"; 

                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }  
        public int CreatedByUserID { get; set; }

        public ManageUserBLL CreatedByUserInfo; 

         public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;  
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }
         private clsApplication(int applicationID, int applicantPersonID, DateTime applicationDate,
                            int applicationTypeID, enApplicationStatus applicationStatus, DateTime lastStatusDate,
                            decimal paidFees, int createdByUserID)
        {
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.PersonInfo = ManagePeopleBLL.FindPeopleById(applicantPersonID);
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.CreatedByUserInfo = ManageUserBLL.FindUserByID(CreatedByUserID);

            Mode = enMode.Update;
        } 
        private bool _AddNewApplication()
        {
             this.ApplicationID = clsApplicationData.AddNewApplication(
                this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID,
               (byte) this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
                return clsApplicationData.UpdateApplication(
                this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate,
                this.PaidFees, this.CreatedByUserID);
        }

      
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                         Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateApplication();
            }

            return false;
        }
         
        public static clsApplication FindBaseApplication(int applicationID)
        {
            int personID = -1, typeID = -1, createdBy = -1;
            DateTime appDate = DateTime.Now, lastStatusDate = DateTime.Now;
            byte status = 1;
            decimal fees = 0;

            bool isFound = clsApplicationData.GetApplicationInfoByID(
                applicationID, ref personID, ref appDate, ref typeID,
                ref status, ref lastStatusDate, ref fees, ref createdBy);

            if (isFound)
            {
                 return new clsApplication(applicationID, personID, appDate, typeID, (enApplicationStatus) status, lastStatusDate, fees, createdBy);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplication();
        }

        public static bool DeleteApplication(int applicationID)
        {
            return clsApplicationData.DeleteApplication(applicationID);
        }

        public static bool IsApplicationExist(int applicationID)
        {
            return clsApplicationData.IsApplicationExist(applicationID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int personID, int applicationTypeID, int licenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(personID, applicationTypeID, licenseClassID);
        }
         
        public bool UpdateStatus(enApplicationStatus newStatus)
        {
             if (clsApplicationData.UpdateStatus(this.ApplicationID, (byte) newStatus))
            {
                 this.ApplicationStatus = newStatus;
                return true;
            }
            return false;
        }
    }
}