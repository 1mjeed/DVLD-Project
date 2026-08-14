using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDAL; 

namespace DVLBLL
{
    public class TestTypesBLL
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public TestTypesBLL.enTestType ID { set; get; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal  Fees { get; set; }
        public TestTypesBLL()
        {
            this.ID = TestTypesBLL.enTestType.VisionTest;
            this.title = "";
            this.description = "";
            this.Fees = 0;
            Mode = enMode.AddNew;

        }
        public TestTypesBLL(TestTypesBLL.enTestType id , string title, string description, decimal Fees)
        {
            this.ID = id;
            this.title = title;
            this.description = description;
            this.Fees = Fees;
        }
        public static TestTypesBLL GetTypeByID(TestTypesBLL.enTestType id)
        {
            string titel = "", description = ""; decimal fees = 0;
            if (TestTypesDAL.GetTestTypeByID((int) id, ref titel, ref description, ref fees)) {
                return new TestTypesBLL(id , titel , description , fees);
            }
            else
            {
                return null; 
            }
        }
        public static DataTable GetAllTestTypes()
        {
            return TestTypesDAL.GetAllInfo();
        }
        //public static TestTypesBLL FindLastTestPerPersonAndLicenseClass
        //  (int PersonID, int LicenseClassID, TestTypesBLL.enTestType TestTypeID)
        //{
        //    int TestID = -1;
        //    int TestAppointmentID = -1;
        //    bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

        //    if (clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass
        //        (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
        //    ref TestAppointmentID, ref TestResult,
        //    ref Notes, ref CreatedByUserID))

        //        return new clsTest(TestID,
        //                TestAppointmentID, TestResult,
        //                Notes, CreatedByUserID);
        //    else
        //        return null;

        //}
        private bool _AddNewTestType()
        { 
            this.ID = (TestTypesBLL.enTestType)TestTypesDAL.AddNewTestType(this.title, this.description, this.Fees);
            return (this.title != "");
        }
        private bool _UpdateTestType()
        {
            return TestTypesDAL.UpdateTestType((int) ID, this.title, this.description , this.Fees);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTestType();
            }

            return false;
        }
    }
}
