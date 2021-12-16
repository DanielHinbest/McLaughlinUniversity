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
    /// Interaction logic for CommitteePerformanceReport.xaml
    /// </summary>
    public partial class CommitteePerformanceReport : UserControl
    {
        public CommitteePerformanceReport()
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
                string quarter = cmbQuarter.Text;
                int year = Convert.ToInt32(cmbYear.Text);
                //Stores the connection settings in the variable
                string connectString = DataAccess.GetConnectionString();

                //Connection for the SQL database
                SqlConnection connection = new SqlConnection(connectString);

                //Opens the connection
                connection.Open();

                //SQL search query
                string selectRecords = null;

                if (quarter == "First Quarter")
                {
                    selectRecords = "SELECT CONCAT(committeeFirstName, ' ', committeeLastName) as 'Committee Member', firstQuarterTarget, SUM(transactionAmount) as 'Contributions', (SUM(transactionAmount) / firstQuarterTarget) *100 as '% of target achieved' " +
                        "FROM tblTargets, tblCommitteeTargets " +
                        "INNER JOIN tblCommitteeMember ON tblCommitteeMember.committeeID = tblCommitteeTargets.committeeID AND targetID = tblCommitteeTargets.targetID " +
                        "INNER JOIN tblTransactions ON tblTransactions.committeeID = tblCommitteeMember.committeeID " +
                        "WHERE yearNo = " + year + " " +
                        "GROUP BY committeeFirstName, committeeLastName, firstQuarterTarget;";
                }
                else if (quarter == "Second Quarter")
                {
                    selectRecords = "SELECT CONCAT(committeeFirstName, ' ', committeeLastName) as 'Committee Member', secondQuarterTarget, SUM(transactionAmount) as 'Contributions', (SUM(transactionAmount) / secondQuarterTarget) *100 as '% of target achieved' " +
                        "FROM tblTargets, tblCommitteeTargets " +
                        "INNER JOIN tblCommitteeMember ON tblCommitteeMember.committeeID = tblCommitteeTargets.committeeID AND targetID = tblCommitteeTargets.targetID " +
                        "INNER JOIN tblTransactions ON tblTransactions.committeeID = tblCommitteeMember.committeeID " +
                        "WHERE yearNo = " + year + " " +
                        "GROUP BY committeeFirstName, committeeLastName, secondQuarterTarget;";
                }
                else if (quarter == "Third Quarter")
                {
                    selectRecords = "SELECT CONCAT(committeeFirstName, ' ', committeeLastName) as 'Committee Member', thirdQuarterTarget, SUM(transactionAmount) as 'Contributions', (SUM(transactionAmount) / thirdQuarterTarget) *100 as '% of target achieved' " +
                        "FROM tblTargets, tblCommitteeTargets " +
                        "INNER JOIN tblCommitteeMember ON tblCommitteeMember.committeeID = tblCommitteeTargets.committeeID AND targetID = tblCommitteeTargets.targetID " +
                        "INNER JOIN tblTransactions ON tblTransactions.committeeID = tblCommitteeMember.committeeID " +
                        "WHERE yearNo = " + year + " " +
                        "GROUP BY committeeFirstName, committeeLastName, thirdQuarterTarget;";
                }
                else if (quarter == "Fourth Quarter")
                {
                    selectRecords = "SELECT CONCAT(committeeFirstName, ' ', committeeLastName) as 'Committee Member', fourthQuarterTarget, SUM(transactionAmount) as 'Contributions', (SUM(transactionAmount) / fourthQuarterTarget) *100 as '% of target achieved' " +
                        "FROM tblTargets, tblCommitteeTargets " +
                        "INNER JOIN tblCommitteeMember ON tblCommitteeMember.committeeID = tblCommitteeTargets.committeeID AND targetID = tblCommitteeTargets.targetID " +
                        "INNER JOIN tblTransactions ON tblTransactions.committeeID = tblCommitteeMember.committeeID " +
                        "WHERE yearNo = " + year + " " +
                        "GROUP BY committeeFirstName, committeeLastName, fourthQuarterTarget;";
                }

                //Executes the command
                SqlCommand command = new SqlCommand(selectRecords, connection);

                //Retrieves the data from the database
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                //A new data table for the targets in the database
                DataTable data = new DataTable("Targets");

                //Fills the data adapter with the information from the data table
                dataAdapter.Fill(data);

                //Outputs the items to the screen
                dgCommitteePerformanceReport.ItemsSource = data.DefaultView;

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
