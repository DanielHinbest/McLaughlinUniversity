using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace McLaughlinUniversity
{
    /// <summary>
    /// Interaction logic for ContributionsToProgramsByDonorCategory.xaml
    /// </summary>
    public partial class ContributionsToProgramsByDonorCategory : UserControl
    {
        public ContributionsToProgramsByDonorCategory()
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
                string selectRecords = "SELECT donorTypeName, programTypeName, transactionAmount " +
                    "FROM tblDonorType, tblProgramType, tblDonors " +
                    "INNER JOIN tblTransactions ON tblDonors.donorID = tblTransactions.donorID " +
                    "WHERE year(transactionDate) = " + year;

                //Executes the command
                SqlCommand command = new SqlCommand(selectRecords, connection);

                //Retrieves the data from the database
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                //A new data table for the targets in the database
                DataTable data = new DataTable("Targets");

                //Fills the data adapter with the information from the data table
                dataAdapter.Fill(data);

                //Outputs the items to the screen
                dgContributionsToProgramsByDonorCategory.ItemsSource = data.DefaultView;

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
