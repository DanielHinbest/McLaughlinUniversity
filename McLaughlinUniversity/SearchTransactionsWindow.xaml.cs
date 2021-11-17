using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace McLaughlinUniversity
{
    /// <summary>
    /// Interaction logic for SearchTransactionsWindow.xaml
    /// </summary>
    public partial class SearchTransactionsWindow : Window
    {
        public SearchTransactionsWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int transactionID = Convert.ToInt32(txtTransactionID.Text);
            try
            {

                string connectString = DataAccess.GetConnectionString();

                SqlConnection connection = new SqlConnection(connectString);

                connection.Open();

                string searchRecord = "SELECT CONCAT(donorFirstName, ' ', donorLastName) as 'Donor Name', transactionID, transactionAmount, transactionDate, programCategory, CONCAT(committeeFirstName, ' ', committeeLastName) as 'Committee Member Name' " +
                    "FROM tblDonors " +
                    "INNER JOIN tblTransactions ON tblDonors.donorID = tblTransactions.donorID " +
                    "INNER JOIN tblCommitteeMember ON tblCommitteeMember.committeeID = tblTransactions.committeeID " +
                    "INNER JOIN tblPrograms ON tblPrograms.programID = tblTransactions.programID " +
                    "WHERE transactionID = " + transactionID + ";";

                SqlCommand command = new SqlCommand(searchRecord, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable data = new DataTable("Transactions");

                dataAdapter.Fill(data);

                dgSearchResults.ItemsSource = data.DefaultView;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A record with transaction ID " + transactionID + " does not exist.");
            }
        }
    }
}
