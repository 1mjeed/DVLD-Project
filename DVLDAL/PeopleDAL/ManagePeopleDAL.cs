using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DVLDAL
{
    public class ManagePeopleDAL
    {
         public static bool FindPeopleById(int personID, ref string nationalNO, ref string firstName, ref string lastName, ref string secondName, ref string thirdName, ref DateTime dateOfBirth, ref int gendor, ref string address, ref string email, ref string phone,ref int nationalityCountryID, ref string imagePath)
        { 
            bool isFound = false;

            using(SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "SELECT * FROM People WHERE PersonID = @PersonID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nationalNO = reader["NationalNo"].ToString();
                                firstName = reader["FirstName"].ToString();
                                lastName = reader["LastName"].ToString();
                                secondName = reader["SecondName"].ToString();
                                thirdName= reader["ThirdName"] != DBNull.Value ? reader["ThirdName"].ToString() : string.Empty;
                                dateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                gendor = Convert.ToInt32(reader["Gendor"]);
                                address = reader["Address"].ToString();
                                email= reader["Email"]!=DBNull.Value ? reader["Email"].ToString() : string.Empty  ;
                                phone = reader["Phone"].ToString();
                                nationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                                imagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : string.Empty;
                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return isFound;
        }
        public static bool FindPeopleByNationalNo(string nationalNO, ref int personID, ref string firstName, ref string lastName, ref string secondName, ref string thirdName, ref DateTime dateOfBirth, ref int gendor, ref string address, ref string email, ref string phone, ref int nationalityCountryID, ref string imagePath)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "SELECT * FROM People WHERE NationalNo = @NationalNo";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", nationalNO);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personID = Convert.ToInt32(reader["PersonID"]);
                                firstName = reader["FirstName"].ToString();
                                lastName = reader["LastName"].ToString();
                                secondName = reader["SecondName"].ToString();
                                thirdName = reader["ThirdName"] != DBNull.Value ? reader["ThirdName"].ToString() : string.Empty;
                                dateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                gendor = Convert.ToInt32(reader["Gendor"]);
                                address = reader["Address"].ToString();
                                email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;
                                phone = reader["Phone"].ToString();
                                nationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                                imagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : string.Empty;
                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            return isFound;
        }


        public static bool UpdatePerson(int personID, string nationalNO, string firstName, string lastName, string secondName, string thirdName, DateTime dateOfBirth, int gendor, string address, string email, string phone, int nationalityCountryID, string imagePath)
        {
            bool isUpdated = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "UPDATE People SET NationalNo=@NationalNo, FirstName=@FirstName, SecondName=@SecondName, ThirdName=@ThirdName, LastName=@LastName, DateOfBirth=@DateOfBirth, Gendor=@Gendor, Address=@Address, Phone=@Phone, Email=@Email, NationalityCountryID=@NationalityCountryID, ImagePath=@ImagePath WHERE PersonID=@PersonID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    command.Parameters.AddWithValue("@NationalNo", nationalNO);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@SecondName", secondName);
                    command.Parameters.AddWithValue("@ThirdName", thirdName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", gendor);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@ImagePath", imagePath);
                    command.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isUpdated = rowsAffected > 0;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    return isUpdated;
                }
            }
        }

        public static int AddPerson(string nationalNO, string firstName, string lastName, string secondName, string thirdName, DateTime dateOfBirth, int gendor, string address, string email, string phone, string imagePath, int nationalityCountryID)
        {
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "INSERT INTO People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)" +
                    "VALUES(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath)" +
                    " SELECT SCOPE_IDENTITY();";
                using(SqlCommand command = new SqlCommand(sql , connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", nationalNO);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@SecondName", secondName);
                    command.Parameters.AddWithValue("@ThirdName", thirdName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", gendor);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", imagePath);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString() , out int personId ))
                        {
                            result = personId;
                            return personId ; 
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
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "SELECT PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, \r\ncase when Gendor = 0 then 'Male' else  'Female' end as Gendor,DateOfBirth, Address, Phone, Email, NationalityCountryID, ImagePath FROM People;"; 
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
                        Console.WriteLine(ex.ToString());
                    }
                    return dt;

                }

            }

        }
        public static bool IsExist(int id)
        {
            bool isExist = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "SELECT 1 FROM People WHERE PersonID = @PersonID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", id);
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        isExist = count > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            return isExist;
        }
        public static bool IsExist(string nationalNo)
        {
            bool isExist = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "SELECT 1 FROM People WHERE NationalNo = @NationalNo";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", nationalNo);
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        isExist = count > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            return isExist;
        }
        public static bool DeletePerson(int personID)
        {
            bool isDeleted = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                string sql = "DELETE FROM People WHERE PersonID = @PersonID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", personID);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        isDeleted = rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            return isDeleted;
        }
    }
}
