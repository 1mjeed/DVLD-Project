using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDAL
{
    public class clsApplicationData
    {
        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicationPersonID,
          ref DateTime ApplicationDate, ref int ApplicationType, ref byte Applicationstatus,
          ref DateTime LastStatusDate, ref decimal paidFees, ref int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                bool isFound = false;
                string sql = "select * from Applications a where a.ApplicationID = @ApplicationID ;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationPersonID = (int)reader["ApplicationPersonID"];
                                ApplicationDate = (DateTime)reader["ApplicationDate"];
                                ApplicationType = (int)reader["ApplicationType"];
                                Applicationstatus = (byte)reader["ApplicationStatus"];
                                LastStatusDate = (DateTime)reader["LastStatusDate"];
                                paidFees = (decimal)reader["PaidFees"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return isFound;
            }
        }
        public static DataTable GetAllApplication()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = @"SELECT *  FROM Applications";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
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
                    catch (Exception ex) { Console.WriteLine(ex.Message); }

                }
            }

             return dt;
        }
        public static int AddNewApplication(int ApplicationPersonID, DateTime ApplicationDate, int ApplicationType, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
             int newApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = @"INSERT INTO Applications (ApplicationPersonID, ApplicationDate, ApplicationType,ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                       VALUES (@ApplicationPersonID, @ApplicationDate, @ApplicationType, 
                        @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
                        SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationType", ApplicationType);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            newApplicationID = insertedID;
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }
             return newApplicationID;
        }
        public static bool UpdateApplication(int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate,int ApplicationType, byte ApplicationStatus, DateTime LastStatusDate,decimal PaidFees, int CreatedByUserID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                 string sql = @"UPDATE Applications 
                       SET ApplicationPersonID = @ApplicationPersonID, 
                           ApplicationDate = @ApplicationDate, 
                           ApplicationType = @ApplicationType, 
                           ApplicationStatus = @ApplicationStatus, 
                           LastStatusDate = @LastStatusDate, 
                           PaidFees = @PaidFees, 
                           CreatedByUserID = @CreatedByUserID
                       WHERE ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationType", ApplicationType);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    try
                    {
                      connection.Open();
                      rowsAffected = command.ExecuteNonQuery();
                    }             
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }
             return (rowsAffected > 0);
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                 string sql = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                     command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    try
                    {
                        connection.Open();
                         rowsAffected = command.ExecuteNonQuery();
                    }
                     catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }    
             return (rowsAffected > 0);
        }
        public static bool IsApplicationExist(int ApplicationID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "SELECT 1 FROM Applications WHERE ApplicationID = @ApplicationID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    try
                    {
                        connection.Open();
                         object result = command.ExecuteScalar();
                         if (result != null)
                         {
                            isFound = true;
                         }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }

            return isFound;
        }
        public static int GetActiveApplicationID(int PersonID, int ApplicationType)
        {
            int activeApplicationID = -1;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                  string sql = @"SELECT ApplicationID FROM Applications 
                         WHERE ApplicantPersonID = @PersonID 
                         AND ApplicationTypeID = @ApplicationType 
                         AND ApplicationStatus = 1";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationType", ApplicationType);
                    try 
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int appID))
                        {
                            activeApplicationID = appID;
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }
             return activeApplicationID;
        }
        public static bool DosePersonHaveActiveApplication(int PersonID, int ApplicationType)
        {
            return (GetActiveApplicationID(PersonID , ApplicationType)!=-1 );
        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int activeApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                
                string sql = @"SELECT a.ApplicationID 
                       FROM Applications a
                       INNER JOIN LocalDrivingLicenseApplications l ON a.ApplicationID = l.ApplicationID 
                       WHERE a.ApplicantPersonID = @PersonID
                         AND a.ApplicationTypeID = @ApplicationTypeID 
                         AND l.LicenseClassID = @LicenseClassID 
                         AND a.ApplicationStatus = 1";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                     command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    try
                    {
                         connection.Open();
                         object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int appID))
                        {
                            activeApplicationID = appID;
                        }
                    } catch (Exception ex) { Console.WriteLine(ex.ToString()); }


                }
            }

            return activeApplicationID;
        }
        public static bool UpdateStatus(int ApplicationID, byte NewStatus)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                 string sql = @"UPDATE Applications 
                       SET ApplicationStatus = @NewStatus, 
                           LastStatusDate = GETDATE() 
                       WHERE ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@NewStatus", NewStatus);
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }

                }
            }
             return (rowsAffected > 0);
        }




    }
}