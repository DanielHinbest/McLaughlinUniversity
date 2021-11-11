using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace McLaughlinUniversity
{
    class DataAccess
    {
        public static string GetConnectionString()
        {
            return Properties.Settings.Default.connectString;
        }

        public static User GetUser(string userID, string password)
        {
            string connectString = GetConnectionString();

            SqlConnection connection = new SqlConnection(connectString);

            connection.Open();

            string selectUser = "SELECT * FROM tblUsers " +
                "WHERE userID = '" + userID + "' AND password = '" + password + "';";

            SqlCommand command = new SqlCommand(selectUser, connection);
            command.ExecuteNonQuery();
            DataTable data = new DataTable("Users");

            User user = new User();

            user.UserID = data.Rows[0][0].ToString();
            user.Password = data.Rows[0][1].ToString();

            return user;
        }
    }
}
