using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDAL; 
namespace DVLBLL 
{
    public class ApplicationTypesBLL
    {
        public static DataTable GetAllType()
        {
            return ApplicationTypesDAL.GetAllType();
        }
    }
}
