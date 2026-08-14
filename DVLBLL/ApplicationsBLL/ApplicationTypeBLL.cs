using System;

namespace DVLBLL
{
    public class ApplicationTypeBLL
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }
          
        private ApplicationTypeBLL(int applicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationTypeTitle = applicationTypeTitle;
            this.ApplicationFees = applicationFees;
        }

         public static ApplicationTypeBLL Find(int ApplicationTypeID)
        {
            string title = "";
            decimal fees = 0;

            bool isFound = ApplicationTypesDAL.GetApplicationTypeInfoByID(ApplicationTypeID, ref title, ref fees);

            if (isFound)
            {
                return new ApplicationTypeBLL(ApplicationTypeID, title, fees);
            }
            else
            {
                return null;
            }
        }
    }
}