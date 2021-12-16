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
    /// Interaction logic for ContributionsByDonorCategory.xaml
    /// </summary>
    public partial class ContributionsByDonorCategory : UserControl
    {
        public ContributionsByDonorCategory()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            PopulateGrid();
        }


        public void PopulateGrid()
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

                string selectRecords = "";

                //Store the selected quarter
                if (Convert.ToInt32(cmbQrt.Text) == 1)
                {
                    //SQL search query
                    selectRecords = "SELECT donorTypeName, Sum(firstQuarterTarget) as 'Target'," +
                        "SUM(transactionAmount) as 'ThisQuarter', " +
                        "SUM(transactionAmount) / Sum(firstQuarterTarget) * 100 as 'Achieved'" +
                        "FROM tblDonorType, tblTargets, tblDonors, tblDonorTargets, " +
                        "tblTransactions WHERE yearNo = " + year + " and " +
                        "tblDonorType.donorTypeID = tblDonors.donorTypeID " +
                        "and tblTargets.targetID = tblDonorTargets.targetID " +
                        "group by donorTypeName;";
                }
                else if (Convert.ToInt32(cmbQrt.Text) == 2)
                {
                    //SQL search query
                    selectRecords = "SELECT donorTypeName, Sum(secondQuarterTarget) as 'Target'," +
                        "SUM(transactionAmount) as 'ThisQuarter', " +
                        "SUM(transactionAmount) / Sum(secondQuarterTarget) * 100 as 'Achieved'" +
                        "FROM tblDonorType, tblTargets, tblDonors, tblDonorTargets, " +
                        "tblTransactions WHERE yearNo = " + year + " and " +
                        "tblDonorType.donorTypeID = tblDonors.donorTypeID " +
                        "and tblTargets.targetID = tblDonorTargets.targetID " +
                        "group by donorTypeName;";
                }
                else if (Convert.ToInt32(cmbQrt.Text) == 3)
                {
                    //SQL search query
                    selectRecords = "SELECT donorTypeName, Sum(thirdQuarterTarget) as 'Target'," +
                        "SUM(transactionAmount) as 'ThisQuarter', " +
                        "SUM(transactionAmount) / Sum(thirdQuarterTarget) * 100 as 'Achieved'" +
                        "FROM tblDonorType, tblTargets, tblDonors, tblDonorTargets, " +
                        "tblTransactions WHERE yearNo = " + year + " and " +
                        "tblDonorType.donorTypeID = tblDonors.donorTypeID " +
                        "and tblTargets.targetID = tblDonorTargets.targetID " +
                        "group by donorTypeName;";
                }
                else
                {
                    //SQL search query
                    selectRecords = "SELECT donorTypeName, Sum(fourthQuarterTarget) as 'Target'," +
                        "SUM(transactionAmount) as 'ThisQuarter', " +
                        "SUM(transactionAmount) / Sum(fourthQuarterTarget) * 100 as 'Achieved'" +
                        "FROM tblDonorType, tblTargets, tblDonors, tblDonorTargets, " +
                        "tblTransactions WHERE yearNo = " + year + " and " +
                        "tblDonorType.donorTypeID = tblDonors.donorTypeID " +
                        "and tblTargets.targetID = tblDonorTargets.targetID " +
                        "group by donorTypeName;";
                }

                //Executes the command
                SqlCommand command = new SqlCommand(selectRecords, connection);

                //Retrieves the data from the database
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                //A new data table for the targets in the database
                DataTable data = new DataTable("Projections");

                //Fills the data adapter with the information from the data table
                dataAdapter.Fill(data);

                //Outputs the items to the screen
                dgContributionByDonorCategory.ItemsSource = data.DefaultView;

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
