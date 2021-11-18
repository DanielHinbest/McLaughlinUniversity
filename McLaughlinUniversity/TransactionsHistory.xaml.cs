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
    /// Interaction logic for TransactionsHistory.xaml
    /// </summary>
    public partial class TransactionsHistory: Window
    {
        public TransactionsHistory()
        {
            InitializeComponent();
            populateGrid();
        }

        private void populateGrid()
        {
            try
            {
                string connectString = DataAccess.GetConnectionString();

                SqlConnection connection = new SqlConnection(connectString);

                connection.Open();

                string searchRecord = "SELECT CONCAT(donorFirstName, ' ', donorLastName) as 'Donor Name', transactionID, transactionAmount, transactionDate, programCategory " +
                    "FROM tblDonors " +
                    "INNER JOIN tblTransactions ON tblDonors.donorID = tblTransactions.donorID " +
                    "INNER JOIN tblPrograms ON tblPrograms.programID = tblTransactions.programID; ";

                SqlCommand command = new SqlCommand(searchRecord, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable data = new DataTable("TransactionsHistory");

                dataAdapter.Fill(data);

                dgTransactionsHistory.ItemsSource = data.DefaultView;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No history available");
            }
        }
    }
}
