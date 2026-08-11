using System.Data.SqlClient;
using System;
using System.Data;
namespace DVLDAL
{
    public class ApplicationTypesDAL
    {
        public static DataTable GetAllType()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "select * from ApplicationTypes";
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
                    return dt;
                }
            }
        }
    }
}
