using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 

namespace DVLDAL.ApplicationDAL
{
    public class TestTypesDAL
    {
        public static bool GetTestTypeByID(int id, ref string title, ref string description, ref decimal fees)
        {
            bool Isfound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "select * from TestTypes t where t.TestTypeID = @TestTypeID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        connection.Open();
                      title = (string)reader["TestTypeTitle"];
                      description = (string)reader["TestTypeDescription"];
                      fees = (decimal)reader["TestTypeFees"];
                        Isfound = true;
                    }

                }
            }
            return Isfound;

        } 
        public static DataTable GetAllInfo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "Select * from TestTypes ";
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
        public static bool UpdateTestType(int id )
        {

        }


    }
}
