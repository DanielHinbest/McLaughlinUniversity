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
    /// Interaction logic for IndividualCampusTargetsReport.xaml
    /// </summary>
    public partial class IndividualCampusTargetsReport : UserControl
    {
        public IndividualCampusTargetsReport()
        {
            InitializeComponent();
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            //Try/Catch exception handling
            try
            {
                //Stores the connection settings in the variable
                string connectString = DataAccess.GetConnectionString();

                //Connection for the SQL database
                SqlConnection connection = new SqlConnection(connectString);

                //Opens the connection
                connection.Open();

                //SQL search query
                string selectRecords = "SELECT campusName as 'Campus Name', SUM(firstQuarterTarget) as 'Qrt 1', SUM(secondQuarterTarget) as 'Qrt 2', SUM(thirdQuarterTarget) as 'Qrt 3', SUM(fourthQuarterTarget) as 'Qrt 4' " +
                    "FROM tblCampus, tblTargets, tblProgramTargets " +
                    "GROUP BY campusName;";

                //Executes the command
                SqlCommand command = new SqlCommand(selectRecords, connection);

                //Retrieves the data from the database
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                //A new data table for the targets in the database
                DataTable data = new DataTable("Targets");

                //Fills the data adapter with the information from the data table
                dataAdapter.Fill(data);

                //Outputs the items to the screen
                dgIndividualCampusTargetsReport.ItemsSource = data.DefaultView;

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
