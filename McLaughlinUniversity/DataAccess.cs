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

        

        public static bool InsertNewDonor(Donor insertDonor)
        {
            bool returnValue = false;

            string connectString = GetConnectionString();
            SqlConnection connection = new SqlConnection(connectString);

            SqlCommand command = new SqlCommand("INSERT INTO tblDonors VALUES(@donorFirstName, @donorLastName, @donorEmailAddress, @donorPhoneNo, @corporationName, @foundationName, @donorTypeID)", connection);
            command.Parameters.AddWithValue("@donorFirstName", insertDonor.FirstName);
            command.Parameters.AddWithValue("@donorLastName", insertDonor.LastName);
            command.Parameters.AddWithValue("@donorEmailAddress", insertDonor.EmailAddress);
            command.Parameters.AddWithValue("@donorPhoneNo", insertDonor.PhoneNo);
            command.Parameters.AddWithValue("@corporationName", insertDonor.CorporationName);
            command.Parameters.AddWithValue("@foundationName", insertDonor.FoundationName);
            command.Parameters.AddWithValue("@donorTypeID", insertDonor.DonorTypeID);

            try
            {
                connection.Open();
                returnValue = (command.ExecuteNonQuery() == 1);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("A database error has been encountered: " + Environment.NewLine + ex.Message, "Database Error");
            }
            finally
            {
                connection.Close();
            }

            return returnValue;
        }

    }
}
