using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace McLaughlinUniversity
{
    class DataAccess
    {
        private static string GetConnectionString()
        {
            return Properties.Settings.Default.connectString;
        }

        private static void GetUser()
        {
            string connectString = GetConnectionString();

            SqlConnection connection = new SqlConnection(connectString);

            connection.Open();

            string selectUser = "SELECT * FROM tblUsers " +
                "WHERE userID = '" + txtUserID.Text + "' AND password = '" + txtPassword.Password + "';";

            SqlCommand command = new SqlCommand(selectUser, connection);
            command.ExecuteNonQuery();

            User user = new User();
            user.UserID
        }
    }
}
