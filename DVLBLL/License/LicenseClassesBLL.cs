using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDAL;

namespace DVLBLL
{
    public class LicenseClassesBLL
    {
        public static DataTable AllClassesInfo()
        {
            return LicenseClassesDAL.AllClassesInfo();
        }


    }
}
