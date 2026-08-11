using System.Data.SqlClient;
using System;
using System.Data;
namespace DVLDAL
{
    public class ApplicationTypesDAL
    {
        public static bool GetApplicationTypeByID(int applicationTypeID, ref string applicationTypeTitle, ref decimal applicationFees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "SELECT ApplicationTypeTitle, ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                             applicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                             applicationFees = (decimal)reader["ApplicationFees"];
                             isFound = true;
                        }
                    }
                }
            }

            return isFound;
        }
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
        public static bool UpdateApplicationType(int applicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                 string sql = @"UPDATE ApplicationTypes 
                       SET ApplicationTypeTitle = @ApplicationTypeTitle, 
                           ApplicationFees = @ApplicationFees 
                       WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", applicationTypeTitle);
                    command.Parameters.AddWithValue("@ApplicationFees", applicationFees);

                     connection.Open();

                     rowsAffected = command.ExecuteNonQuery();
                }
            }

             return (rowsAffected > 0);
        }
    }
}
