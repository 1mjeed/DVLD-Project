using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDAL 
{
    public class LicenseClassesDAL
    {
        // I can Dleleted it  
        public static DataTable AllClassesInfo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "Select ClassName , LicenseClassID from LicenseClasses";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                      
                    }
                }
                return dt;

            }
        }
    }
}
