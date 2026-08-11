using DVLDAL;
using System;
using System.Data;

namespace DVLBLL
{
    public class ApplicationTypeBLL
    { 
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

 
        private ApplicationTypeBLL(int id, string title, decimal fees)
        {
            this.ApplicationTypeID = id;
            this.ApplicationTypeTitle = title;
            this.ApplicationFees = fees;
        }
 

        public static DataTable GetAllApplicationTypes()
        {
            return ApplicationTypesDAL.GetAllType();
        }
        public static ApplicationTypeBLL Find(int id)
        {
            string title = "";
            decimal fees = 0;            
            if (ApplicationTypesDAL.GetApplicationTypeByID(id, ref title, ref fees))
            {
                 return new ApplicationTypeBLL(id, title, fees);
            }
            else
            {
                return null;
            }
        }     
        public bool Save()
        {            
            return ApplicationTypesDAL.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }
    }
}