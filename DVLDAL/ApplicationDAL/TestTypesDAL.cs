using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 

namespace DVLDAL 
{
    public class TestTypesDAL
    {
        public static bool GetTestTypeByID(int id, ref string title, ref string description, ref decimal fees)
        {
            bool Isfound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "select t.TestTypeID , t.TestTypeTitle , t.TestTypeDescription , t.TestTypeFees from TestTypes t  where t.TestTypeID = @TestTypeID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            title = (string)reader["TestTypeTitle"];
                            description = (string)reader["TestTypeDescription"];
                            fees = (decimal)reader["TestTypeFees"];
                            Isfound = true;
                        }
                      
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
        public static int AddNewTestType(string Title, string Description, decimal Fees)
        {
            int TestTypeID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Insert Into TestTypes (TestTypeTitle,TestTypeTitle,TestTypeFees)
                            Values (@TestTypeTitle,@TestTypeDescription,@ApplicationFees)
                            where TestTypeID = @TestTypeID;
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return TestTypeID;

        }
        public static bool UpdateTestType(int id, string title, string description, decimal fees)
        {
            int rowEffective = 0; 
             using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "Update TestTypes set TestTypeTitle =@TestTypeTitle ,TestTypeDescription= @TestTypeDescription ,TestTypeFees=@TestTypeFees where TestTypeID = @TestTypeID ;"; 
                using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeTitle", title);
                    command.Parameters.AddWithValue("@TestTypeID", id);
                    command.Parameters.AddWithValue("@TestTypeDescription",  description);
                    command.Parameters.AddWithValue("@TestTypeFees", fees);
                    connection.Open();
                    rowEffective = command.ExecuteNonQuery();

                }
                return (rowEffective > 0);
            }
        }


    }
}
