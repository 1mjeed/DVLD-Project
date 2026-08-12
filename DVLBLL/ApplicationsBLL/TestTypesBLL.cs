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
        public int ID {  get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal  Fees { get; set; }
        public TestTypesBLL(int id, string title, string description, decimal Fees)
        {
            this.ID = id;
            this.title = title;
            this.description = description;
            this.Fees = Fees;
        }
        public static TestTypesBLL GetTypeByID(int id)
        {
            string titel = "", description = ""; decimal fees = 0;
            if (TestTypesDAL.GetTestTypeByID(id, ref titel, ref description, ref fees)) {
                return new TestTypesBLL(id , titel , description , fees);
            }
            else
            {
                return null; 
            }
        }
        public static DataTable GetAllInfo()
        {
            return TestTypesDAL.GetAllInfo();
        }
        private bool _UpdateTestType()
        {
            return TestTypesDAL.UpdateTestType(this.ID , this.title, this.description , this.Fees);
        }
        public bool Save()
        {
            return _UpdateTestType(); 
        }
    }
}
