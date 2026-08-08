using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DVLDAL
{
    public class CountryDAL
    {
        public static DataTable GetAllCountry()
        {
           DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "SELECT * FROM COUNTRIES ";
                using (SqlCommand command = new SqlCommand(sql, connection)) 
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader()) 
                        {
                       dt.Load(reader);
                        
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    return dt;


                }

            }
        }
    }
}
