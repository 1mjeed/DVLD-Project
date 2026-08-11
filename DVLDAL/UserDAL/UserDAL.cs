using System;
using System.Data; 
using System.Collections.Generic;
using System.Data.SqlClient; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDAL
{
    public class UserDAL
    {
        public static bool GetUserInfoByUserID(int UserID , ref int PersonID , ref string UserName , ref string UserPassword , ref bool isActive)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "Select * from Users Where UserID= @UserID"; 

                using(SqlCommand command = new SqlCommand(sql,connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    try  
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                PersonID = (int)reader["PersonID"];
                                UserName = (string)reader["UserName"];
                                UserPassword = (string)reader["Password"];
                                isActive = (bool)reader["IsActive"];

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }


            }
            return isFound; 
        }
        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName , ref string UserPassword , ref bool isActive)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "Select * from Users Where PersonID= @PersonID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserID = (int)reader["UserID"];
                                UserName = (string)reader["UserName"];
                                UserPassword = (string)reader["Password"];
                                isActive = (bool)reader["IsActive"];

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }


            }
            return isFound;
        }
        public static int AddNewUser(int PersonID,string UserName,string UserPassword,bool isActive )
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "INSERT INTO  Users ( PersonID,UserName,Password,IsActive)" +
                    "VALUES (@PersonID,@UserName,@UserPassword,@isActive);" +
                    "Select SCOPE_IDENTITY()";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@UserPassword", UserPassword);
                    command.Parameters.AddWithValue("@isActive", isActive);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int UserId))
                        {
                             return UserId;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                return -1;
            } 
        }
        public static bool UpdateUser(int UserID, int PersonID, string UserName, string UserPassword, bool isActive)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                 string sql = @"UPDATE Users SET 
                           PersonID = @PersonID, 
                           UserName = @UserName, 
                           Password = @Password, 
                           IsActive = @IsActive 
                       WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", UserPassword);
                    command.Parameters.AddWithValue("@IsActive", isActive);

                    try
                    {
                         connection.Open();
                         rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
             return (rowsAffected > 0);
        }
        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                 string sql = "DELETE FROM Users WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                     command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                         connection.Open();
                         rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                         Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return (rowsAffected > 0);
        }
 
        public static DataTable GetAllUsers()
    {
         DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
        {
             string sql = "Select u.UserID ,u.PersonID,( p.FirstName + ' ' + p.SecondName + ' ' +p.ThirdName + ' ' +p.LastName) as FullName , u.Password , u.UserName , u.IsActive from Users u inner Join People p on u.PersonID = p.PersonID";

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
                catch (Exception ex)
                {
                     Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        return dt;
    }
        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
               string sql = "SELECT 1 FROM Users WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                         connection.Open();
                         object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            isFound = true; 
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return isFound;
        }
        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
               string sql = "SELECT 1 FROM Users WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    try
                    {
                         connection.Open();
                         object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            isFound = true; 
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return isFound;
        }
        public static bool IsUserExistforPassword(string Password)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
               string sql = "SELECT 1 FROM Users WHERE Password = @Password";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Password", Password);
                    try
                    {
                         connection.Open();
                         object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            isFound = true; 
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return isFound;
        }
        public static bool Login(string UserName , string Password )
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "SELECT 1 FROM Users WHERE Password = @Password AND UserName = @UserName AND IsActive=1";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            isFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return isFound;
        }

        public static bool ChangePassword(int id, string Password) 
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                int rowEf= 0 ;
                string sql = "Update Users set Password = @pass Where UserID = @UserID "; 
                using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@pass" , Password);
                    command.Parameters.AddWithValue("@UserID" , id);
                    try
                    {
                        connection.Open();
                       rowEf = command.ExecuteNonQuery();
                        
                    }
                    catch (Exception ex) 
                    {
                        throw new Exception("Database Error: " + ex.Message);
                    }
                }
                return (rowEf > 0);
            }


        }
        

    }
}
