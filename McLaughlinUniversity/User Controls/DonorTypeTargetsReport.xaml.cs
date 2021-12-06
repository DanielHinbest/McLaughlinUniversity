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
    /// Interaction logic for DonorTypeTargetsReport.xaml
    /// </summary>
    public partial class DonorTypeTargetsReport : UserControl
    {
        public DonorTypeTargetsReport()
        {
            InitializeComponent();
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

                //SQL search query
                string selectRecords = "SELECT donorTypeName, SUM(firstQuarterTarget) as 'Qtr 1', SUM(secondQuarterTarget) as 'Qtr 2', SUM(thirdQuarterTarget) as 'Qtr 3', SUM(fourthQuarterTarget) as 'Qtr 4' " +
                    "FROM tblDonorType, tblTargets " +
                    "WHERE yearNo = " + cmbYear.Text +
                    "GROUP BY donorTypeName;";

                //Executes the command
                SqlCommand command = new SqlCommand(selectRecords, connection);

                //Retrieves the data from the database
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                //A new data table for the targets in the database
                DataTable data = new DataTable("Projections");

                //Fills the data adapter with the information from the data table
                dataAdapter.Fill(data);

                //Outputs the items to the screen
                dgDonorTypeTargetsReport.ItemsSource = data.DefaultView;

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
