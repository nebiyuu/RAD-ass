using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.Data.SqlClient;

namespace myproject.Classes
{
    public class Student
    {
        // Properties
        public string Username { get; set; }
        public string Password { get; set; }

        // Constructor
        public Student(string username, string password)
        {
            Username = username;
            Password = password;
        }

        // Method to authenticate the student
        public bool Authenticate()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                throw new ArgumentException("Username and Password are required!");
            }

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Query to check if the user exists
                    string query = "SELECT COUNT(1) FROM auth WHERE username = @UserID AND pass = @Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", Username);
                        command.Parameters.AddWithValue("@Password", Password);

                        connection.Open();
                        int userExists = Convert.ToInt32(command.ExecuteScalar());

                        return userExists == 1; // Return true if the user exists
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
    }
}