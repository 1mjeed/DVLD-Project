using System;
using System.Collections.Generic;
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
        public static bool GetApplicationTypeByID(int id, ref string title, ref string description, ref decimal fees)
        {
            return TestTypesDAL.GetApplicationTypeByID(id, ref title, ref description, ref fees);
        } 
            }
}
