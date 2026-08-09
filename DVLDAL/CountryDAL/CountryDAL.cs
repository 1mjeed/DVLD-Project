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
        public static string GetCountryName(int id )
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "select c.CountryName from Countries c where c.CountryID =@CountryID";
                using (SqlCommand command = new SqlCommand(sql , connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@CountryID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string ContryName = (string)reader["CountryName"];
                            return ContryName;
                        }
                    }
                }
                return "not Found Country This Return from DAL";
            
            }

        }
    }
}
