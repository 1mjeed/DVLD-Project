using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDAL; 
namespace DVLBLL.CountryBLL
{
    public class CountryBLL
    {
        

        public static DataTable GetAllCountry()
        {
            return CountryDAL.GetAllCountry();
        }

    }
}
