using DVLDAL;
using System;
using System.Data;
using System.Data.SqlClient;

public class clsLocalDrivingLicenseApplicationData
{
    public static bool GetLocalDrivingLicenseApplicationInfoByID(
        int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
    {
        bool isFound = false;


        using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
        {
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            ApplicationID = (int)reader["ApplicationID"];
                            LicenseClassID = (int)reader["LicenseClassID"];
                        }
                    }  

                }
                catch (Exception ex)
                {                    
                    isFound = false;
                } 
            }
        }  

        return isFound;
    }

    public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(
        int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
    {
        bool isFound = false;

          using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
          {
                string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                  try
                  {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                            LicenseClassID = (int)reader["LicenseClassID"];
                        }
                    }
                  }
                  catch (Exception ex)
                  {
                    isFound = false;
                  }
                }
          }
        

        return isFound;
    }

    public static DataTable GetAllLocalDrivingLicenseApplications()
    {
        DataTable dt = new DataTable();

       
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"SELECT * FROM LocalDrivingLicenseApplications_View order by ApplicationDate Desc";

              using (SqlCommand command = new SqlCommand(query, connection))
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
                 }  catch (Exception ex) {  }
              }
            }
      

        return dt;
    }

    public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
    {
        int LocalDrivingLicenseApplicationID = -1;

        
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                                 VALUES (@ApplicationID, @LicenseClassID);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                 try
                 {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        LocalDrivingLicenseApplicationID = insertedID;
                    }
                 } catch (Exception ex) { }
                }
            }
        return LocalDrivingLicenseApplicationID;

    }




    public static bool UpdateLocalDrivingLicenseApplication(
        int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
    {
        int rowsAffected = 0;        
       using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
       {
         string query = @"Update LocalDrivingLicenseApplications  
                                 set ApplicationID = @ApplicationID,
                                     LicenseClassID = @LicenseClassID
                                 where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

          using (SqlCommand command = new SqlCommand(query, connection))
          {
             command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
             command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
             command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return false;
                }

          }
       }
        return (rowsAffected > 0);
    }
        
     
    

    public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
    {
        int rowsAffected = 0;

        using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
        {
            string query = @"Delete LocalDrivingLicenseApplications 
                                 where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                try
                {

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex) { }
            }
        }
        return (rowsAffected > 0);
    }

    public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
    {
        bool Result = false;
        using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
        {
            string query = @"SELECT top 1 TestResult
                                 FROM LocalDrivingLicenseApplications INNER JOIN
                                      TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                      Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                 WHERE (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                                   AND (TestAppointments.TestTypeID = @TestTypeID)
                                 ORDER BY TestAppointments.TestAppointmentID desc";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                    {
                        Result = returnedResult;
                    }
                }
                catch (Exception ex) { }
            }
        }

        return Result;
    }

    public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
    {
        bool IsFound = false;

          using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
          {
              string query = @"SELECT top 1 Found=1
                                 FROM LocalDrivingLicenseApplications INNER JOIN
                                      TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                      Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                 WHERE (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                                   AND (TestAppointments.TestTypeID = @TestTypeID)
                                 ORDER BY TestAppointments.TestAppointmentID desc";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                  try
                  {

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        IsFound = true;
                    }
                  }  catch (Exception ex)  { }
                }
          }
       

        return IsFound;
    }

    public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
    {
        byte TotalTrialsPerTest = 0;
      using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string query = @"SELECT TotalTrialsPerTest = count(TestID)
                                 FROM LocalDrivingLicenseApplications INNER JOIN
                                      TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                      Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                 WHERE (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                                   AND (TestAppointments.TestTypeID = @TestTypeID)";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
           command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
           command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
             try
             {
                  connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                    {
                        TotalTrialsPerTest = Trials;
                    }
             }  catch (Exception ex) { }
        }
      }
        return TotalTrialsPerTest;
    }




    public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
    {
        bool Result = false;


        using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
        {
            string query = @"SELECT top 1 Found=1
                                 FROM LocalDrivingLicenseApplications INNER JOIN
                                      TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                                 WHERE (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                                   AND (TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                                 ORDER BY TestAppointments.TestAppointmentID desc";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        Result = true;
                    }

                }
                catch (Exception ex)
                {
                    // لا شيء
                }
            }
        }

        return Result;
    }
}