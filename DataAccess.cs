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
            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nazar\\Downloads\\McLaughlinUniversity-master\\McLaughlinUniversity\\McLaughlinUniversity.mdf\";Integrated Security=True;";
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

        public static bool InsertNewTransaction(Transaction newTransaction)
        {
            bool returnValue = false;

            string connectString = GetConnectionString();
            SqlConnection connection = new SqlConnection(connectString);

            SqlCommand command = new SqlCommand("INSERT INTO tblTransactions VALUES(@transactionAmount, @transactionDate, @donorID, @programID, @committeeID)", connection);
            command.Parameters.AddWithValue("@transactionAmount", newTransaction.Amount);
            command.Parameters.AddWithValue("@transactionDate", newTransaction.Date);
            command.Parameters.AddWithValue("@donorID", newTransaction.DonorID);
            command.Parameters.AddWithValue("@programID", newTransaction.ProgramID);
            command.Parameters.AddWithValue("@committeeID", newTransaction.CommitteeID);

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
