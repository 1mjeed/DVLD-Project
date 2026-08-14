using DVLDAL;
using System;
using System.Data.SqlClient;

public class ApplicationTypesDAL
{
    public static bool GetApplicationTypeInfoByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationFees)
    {
        bool isFound = false;

        try
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];

                             ApplicationFees = Convert.ToDecimal(reader["ApplicationFees"]);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            isFound = false;
        }

        return isFound;
    }
}