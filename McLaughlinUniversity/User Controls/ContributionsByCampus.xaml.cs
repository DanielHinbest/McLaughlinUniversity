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
    /// Interaction logic for ContributionsByCampus.xaml
    /// </summary>
    public partial class ContributionsByCampus : UserControl
    {
        public ContributionsByCampus()
        {
            InitializeComponent();
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
                    selectRecords = "SELECT tblCampus.campusName as 'Campus Name', SUM(tblTargets.firstQuarterTarget) as 'This Quarter', (SUM(transactionAmount) / firstQuarterTarget) *100 as '% of target achieved' " +
                        "FROM tblCampus, tblTransactions, ((tblProgramTargets " +
                        "INNER JOIN tblTargets ON tblProgramTargets.targetID = tblTargets.targetID) " +
                        "INNER JOIN tblPrograms ON tblPrograms.campusName = campusName) " +
                        "WHERE yearNo = " + year + " " +
                        "GROUP BY tblCampus.campusName, tblTargets.firstQuarterTarget;";
                }
                else if (quarter == "Second Quarter")
                {
                    selectRecords = "SELECT tblCampus.campusName as 'Campus Name', SUM(tblTargets.secondQuarterTarget) as 'This Quarter', (SUM(transactionAmount) / secondQuarterTarget) *100 as '% of target achieved' " +
                        "FROM tblCampus, tblTransactions, ((tblProgramTargets " +
                        "INNER JOIN tblTargets ON tblProgramTargets.targetID = tblTargets.targetID) " +
                        "INNER JOIN tblPrograms ON tblPrograms.campusName = campusName) " +
                        "WHERE yearNo = " + year + " " +
                        "GROUP BY tblCampus.campusName, tblTargets.secondQuarterTarget;";
                }
                else if (quarter == "Third Quarter")
                {
                    selectRecords = "SELECT tblCampus.campusName as 'Campus Name', SUM(tblTargets.thirdQuarterTarget) as 'This Quarter', (SUM(transactionAmount) / thirdQuarterTarget) *100 as '% of target achieved' " +
                        "FROM tblCampus, tblTransactions, ((tblProgramTargets " +
                        "INNER JOIN tblTargets ON tblProgramTargets.targetID = tblTargets.targetID) " +
                        "INNER JOIN tblPrograms ON tblPrograms.campusName = campusName) " +
                        "WHERE yearNo = " + year + " " +
                        "GROUP BY tblCampus.campusName, tblTargets.thirdQuarterTarget;";
                }
                else if (quarter == "Fourth Quarter")
                {
                    selectRecords = "SELECT tblCampus.campusName as 'Campus Name', SUM(tblTargets.fourthQuarterTarget) as 'This Quarter', (SUM(transactionAmount) / fourthQuarterTarget) *100 as '% of target achieved' " +
                        "FROM tblCampus, tblTransactions, ((tblProgramTargets " +
                        "INNER JOIN tblTargets ON tblProgramTargets.targetID = tblTargets.targetID) " +
                        "INNER JOIN tblPrograms ON tblPrograms.campusName = campusName) " +
                        "WHERE yearNo = " + year + " " +
                        "GROUP BY tblCampus.campusName, tblTargets.fourthQuarterTarget;";
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
                dgContributionsByCampusReport.ItemsSource = data.DefaultView;

                //Closes the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                //Outputs the error to the user
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            PopulateGrid();
        }
    }
}

