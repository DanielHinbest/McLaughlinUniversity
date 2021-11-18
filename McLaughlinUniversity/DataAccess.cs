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
            return "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " +
                "D:\\Users\\Daniel\\Documents\\Durham College\\Computer Programming and Analysis\\Semester 5\\DBAS 6206\\Final Project\\McLaughlinUniversity\\McLaughlinUniversity\\McLaughlinUniversity.mdf; Integrated Security = True";
        }


        public static User GetUser(string userID, string password)
        {
            User user = new User();

            string connectString = GetConnectionString();

            SqlConnection connection = new SqlConnection(connectString);
            connection.Open();

            string selectUser = "SELECT * FROM tblUsers " +
                "WHERE userID = '" + userID + "' AND password = '" + password + "';";

            SqlCommand command = new SqlCommand(selectUser, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable data = new DataTable("Users");
            dataAdapter.Fill(data);

            if (data.Rows.Count > 0)
            {
                user.UserID = data.Rows[0][0].ToString();
                user.Password = data.Rows[0][1].ToString();
            }
            connection.Close();

            return user;
        }
    }
}
