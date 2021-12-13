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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace McLaughlinUniversity
{
    /// <summary>
    /// Interaction logic for ContributionsList.xaml
    /// </summary>
    public partial class ContributionsList : UserControl
    {
        public ContributionsList()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            //Try/Catch exception handling
            try
            {
                int year = Convert.ToInt32(cmbYear.Text);
                //Stores the connection settings in the variable
                string connectString = DataAccess.GetConnectionString();

                //Connection for the SQL database
                SqlConnection connection = new SqlConnection(connectString);

                //Opens the connection
                connection.Open();

                //SQL search query
                string selectRecords = "SELECT transactionDate, CONCAT(donorFirstName, ' ', donorLastName) as 'Donor', transactionAmount, programTypeName, CONCAT(committeeFirstName, ' ', committeeLastName) as 'Committee Member' " +
                    "FROM tblDonors " +
                    "INNER JOIN tblTransactions ON committeeID = tblTransactions.committeeID AND tblDonors.donorID = tblTransactions.donorID " +
                    "INNER JOIN tblPrograms ON tblPrograms.programID = tblTransactions.programID " +
                    "INNER JOIN tblProgramType ON tblPrograms.programTypeID = tblProgramType.programTypeID " +
                    "INNER JOIN tblCommitteeMember ON tblTransactions.committeeID = tblCommitteeMember.committeeID " +
                    "WHERE year(transactionDate) = " + year + ";";

                //Executes the command
                SqlCommand command = new SqlCommand(selectRecords, connection);

                //Retrieves the data from the database
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                //A new data table for the targets in the database
                DataTable data = new DataTable("Targets");

                //Fills the data adapter with the information from the data table
                dataAdapter.Fill(data);

                //Outputs the items to the screen
                dgContributionsList.ItemsSource = data.DefaultView;

                //Closes the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                //Outputs the error to the user
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
